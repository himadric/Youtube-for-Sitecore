using Sitecore.MediaFramework.Synchronize.Fallback;
using Sitecore.MediaFramework.Youtube.Indexing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.MediaFramework.Youtube.Synchronize.Fallback
{
    public class VideoFallBack : BaseFallBack<VideoSearchResult>
    {
        protected override Data.Items.Item GetItem(object entity, Data.Items.Item accountItem)
        {
            Sitecore.MediaFramework.Youtube.Entities.Video video = (Sitecore.MediaFramework.Youtube.Entities.Video)entity;
            return accountItem.Axes.SelectSingleItem(string.Format("./Media Content//*[@@templateid='{0}' and @id='{1}']", (object)TemplateIDs.Video, (object)video.Id));
        }

        protected override MediaFramework.Entities.MediaServiceSearchResult GetSearchResult(Data.Items.Item item)
        {
            VideoSearchResult videoSearchResult = (VideoSearchResult)base.GetSearchResult(item);
            videoSearchResult.VideoUrl=item[FieldNames.Video.VideoUrl];
            videoSearchResult.StillImageUrl=item[FieldNames.Video.StillImageUrl];
            videoSearchResult.ThumbnailUrl=item[FieldNames.Video.ThumbnailUrl];
            videoSearchResult.UploadDate=item[FieldNames.Video.UploadDate];
            videoSearchResult.VideoFileName=item[FieldNames.Video.VideoFileName];
            videoSearchResult.NumberOfViews = item[FieldNames.Video.Views];
            videoSearchResult.NumberOfLikes=item[FieldNames.Video.Likes];
            videoSearchResult.NumberOfDislikes=item[FieldNames.Video.Dislikes];
            videoSearchResult.NumberOfComments=item[FieldNames.Video.NumberOfComments];
            videoSearchResult.NumberFavorited=item[FieldNames.Video.NumberFavorited];
            videoSearchResult.NumberShared=item[FieldNames.Video.NumberShared];
            return videoSearchResult;
        }
    }
}
