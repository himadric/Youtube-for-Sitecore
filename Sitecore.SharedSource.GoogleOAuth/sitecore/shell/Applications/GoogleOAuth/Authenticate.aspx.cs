using System;
using System.Threading;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;

namespace Sitecore.SharedSource.GoogleOAuth
{
    public partial class Authenticate : System.Web.UI.Page
    {
        private const string AuthUrl = "/sitecore/shell/Applications/GoogleOAuth/Authenticate.aspx";
        private static string _clientId = string.Empty;
        private static string _clientSecret = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            var dataFolder = Configuration.Settings.DataFolder;
            if (_clientId.Equals(string.Empty))
            {
                _clientId = Request.QueryString["ClientId"];
                _clientSecret = Request.QueryString["ClientSecret"];
            }

            GoogleAuthorizationCodeFlow flow;
            flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = _clientId,
                    ClientSecret = _clientSecret
                },
                Scopes = new[] { YouTubeService.Scope.YoutubeReadonly },
                DataStore = new FileDataStore(dataFolder + "\\YouTubeService.api.auth.store")
            });
            var userId = "userId";

            var code = Request["code"];
            if (code != null)
            {
                var uri = Request.Url.ToString();

                var token = flow.ExchangeCodeForTokenAsync(userId, code,
                    uri.Substring(0, uri.IndexOf("?")), CancellationToken.None).Result;

                // Extract the right state.
                var oauthState = AuthWebUtility.ExtracRedirectFromState(
                    flow.DataStore, userId, Request["state"]).Result;
                Response.Redirect(oauthState);
            }
            else
            {
                var uri = "http://" + HttpContext.Current.Request.Url.Authority + AuthUrl;
                var result = new AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(userId,
                    CancellationToken.None).Result;
                if (result.RedirectUri != null)
                {
                    // Redirect the user to the authorization server.
                    Response.Redirect(result.RedirectUri);
                }
                else
                {
                    // The data store contains the user credential, so the user has been already authenticated.
                    var service = new YouTubeService(new BaseClientService.Initializer
                    {
                        ApplicationName = "Youtube API Sample",
                        HttpClientInitializer = result.Credential
                    });
                }
            }


        }
    }
}