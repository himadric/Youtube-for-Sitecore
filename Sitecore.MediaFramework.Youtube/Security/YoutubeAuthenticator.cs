using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Sitecore.Data.Items;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.MediaFramework.Youtube.Security
{
    public class YoutubeAuthenticator
    {
        public static YouTubeService youtubeService = null;
        private const string AuthUrl = "/sitecore/shell/Applications/GoogleOAuth/Authenticate.aspx";


        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public YoutubeAuthenticator(Item accountItem)
        {
            ClientId = accountItem.Fields["ClientId"].Value;
            ClientSecret = accountItem.Fields["ClientSecret"].Value;
        }

        public YouTubeService Authenticate()
        {
            var dataFolder = Configuration.Settings.DataFolder;
            var fileDataStoreLocation = dataFolder + @"\YouTubeService.api.auth.store";
            GoogleAuthorizationCodeFlow flow;
            flow =
                new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets
                    {
                        ClientId = ClientId,     
                        ClientSecret = ClientSecret
                    },
                    Scopes = new[] { YouTubeService.Scope.YoutubeReadonly },
                    DataStore = new FileDataStore(fileDataStoreLocation)
                });
            var userId = "userId";

            var uri = "http://" + HttpContext.Current.Request.Url.Authority + AuthUrl;
            var result = new AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(userId,
                    CancellationToken.None).Result;
            if (result.Credential == null)
            {
                var authUrlWithCredential = string.Format("{0}?ClientId={1}&ClientSecret={2}", AuthUrl, ClientId,
                    ClientSecret);
                SheerResponse.Eval("window.open('" + authUrlWithCredential + "', '_blank', height='500', width='500')");
                return null;
            }
            else
            {
                youtubeService= new YouTubeService(new BaseClientService.Initializer
                {
                    ApplicationName = "Sitecore Media Framework Connector for Youtube.",
                    HttpClientInitializer = result.Credential
                });
                return youtubeService;
            }

        }
    }
}
