using System.Collections.Generic;
using System.Xml;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.MediaFramework.Account;
using Sitecore.MediaFramework.Pipelines.MediaGenerateMarkup;
using Sitecore.MediaFramework.Players;
using Sitecore.Xml;

namespace Sitecore.MediaFramework.Youtube.Players
{
    public class YoutubePlayerMarkupGenerator : PlayerMarkupGeneratorBase
    {
        public override PlayerMarkupResult Generate(MediaGenerateMarkupArgs args)
        {
            var playerMarkupResult = new PlayerMarkupResult();
            var width = args.Properties.Width.ToString();
            var height = args.Properties.Height.ToString();
            var videoId = args.MediaItem[FieldIDs.MediaElement.Id];
            playerMarkupResult.Html = string.Format("<iframe width=\"{0}\" height=\"{1}\" src=\"//www.youtube.com/embed/{2}\" frameborder=\"0\"></iframe>", width, height, videoId);
            return playerMarkupResult;
        }

        public override string GetPreviewImage(MediaGenerateMarkupArgs args)
        {
            return PlayerManager.GetPreviewImage(args, FieldIDs.Video.ThumbnailUrl);
        }

        public override Item GetDefaultPlayer(MediaGenerateMarkupArgs args)
        {
            ID fieldId = args.MediaItem.TemplateID == TemplateIDs.Video ? FieldIDs.AccountSettings.DefaultVideoPlayer : FieldIDs.AccountSettings.DefaultPlaylistPlayer;
            var referenceField = (ReferenceField)AccountManager.GetSettingsField(args.AccountItem, fieldId);
            if (referenceField == null)
                return (Sitecore.Data.Items.Item)null;
            else
                return referenceField.TargetItem;
        }

        public override string GetMediaId(Item item)
        {
            return item[FieldIDs.MediaElement.Id];
        }
    }
}
