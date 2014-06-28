using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sitecore.Data;
using Sitecore.MediaFramework.Commands;
using Sitecore.MediaFramework.Youtube.Security;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.MediaFramework.Youtube.Commands
{
    public class YoutubeImportContent : ImportContent
    {
        public YoutubeImportContent()
        {
        }

        public override void Execute(CommandContext context)
        {
            //var uri = HttpContext.Current.Request.Url.Authority;
            //var websiteUrl = "/sitecore/shell/Applications/GoogleOAuth/Authenticate.aspx";
            //SheerResponse.Eval("window.open('" + websiteUrl + "', '_blank', height='500', width='500')");
            var accountItem = context.Items[0];
            var youtubeService=new YoutubeAuthenticator(accountItem).Authenticate();
            base.Execute(context);
        }

    }
}
