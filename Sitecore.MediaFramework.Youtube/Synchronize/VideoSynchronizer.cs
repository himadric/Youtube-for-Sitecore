using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.MediaFramework.Synchronize;
using Sitecore.MediaFramework.Entities;
using System.Linq.Expressions;
using Sitecore.MediaFramework.Youtube.Indexing.Entities;
using Sitecore.MediaFramework.Youtube.Entities;
using Sitecore.Data.Items;

namespace Sitecore.MediaFramework.Youtube.Synchronize
{
    public class VideoSynchronizer : SynchronizerBase
    {
        public override MediaFramework.Entities.MediaServiceEntityData GetMediaData(object entity)
        {
            BaseEntity baseEntity = (BaseEntity)entity;
            return new MediaServiceEntityData()
            {
                EntityId = baseEntity.Id,
                EntityName = baseEntity.Title,
                TemplateId=TemplateIDs.Video
            };
        }

        public override Data.Items.Item GetRootItem(object entity, Data.Items.Item accountItem)
        {
            return accountItem.Children["Media Content"];
        }

        public override MediaFramework.Entities.MediaServiceSearchResult GetSearchResult(object entity, Data.Items.Item accountItem)
        {
            Sitecore.MediaFramework.Youtube.Entities.Video video = (Sitecore.MediaFramework.Youtube.Entities.Video)entity;
            return (MediaServiceSearchResult)base.GetSearchResult<VideoSearchResult>(Constants.IndexName, accountItem, (Expression<Func<VideoSearchResult, bool>>)(i => i.TemplateId == TemplateIDs.Video && i.Id == video.Id));
        }

        public override bool NeedUpdate(object entity, Data.Items.Item accountItem, MediaFramework.Entities.MediaServiceSearchResult searchResult)
        {
            throw new NotImplementedException();
        }

        public override Data.Items.Item UpdateItem(object entity, Data.Items.Item accountItem, Data.Items.Item item)
        {
            Sitecore.MediaFramework.Youtube.Entities.Video video = (Sitecore.MediaFramework.Youtube.Entities.Video)entity;
            using (new EditContext(item))
            {
                item.Name = ItemUtil.ProposeValidItemName(video.Title);
                item[FieldNames.MediaElement.Id] = video.Id;
                item[FieldNames.MediaElement.Title] = video.Title;
                item[FieldNames.MediaElement.Description] = video.Description;
                item[FieldNames.MediaElement.ChannelName] = video.ChannelName;
                item[FieldNames.Video.VideoUrl] = video.VideoUrl;
                item[FieldNames.Video.StillImageUrl] = video.StillImageUrl;
                item[FieldNames.Video.ThumbnailUrl] = video.ThumbnailUrl;
                item[FieldNames.Video.UploadDate] = video.UploadDate.ToString();
                item[FieldNames.Video.VideoFileName] = video.VideoFileName;
                item[FieldNames.Video.Views] = video.NumberOfViews.ToString();
                item[FieldNames.Video.Likes] = video.NumberOfLikes.ToString();
                item[FieldNames.Video.Dislikes] = video.NumberOfDislikes.ToString();
                item[FieldNames.Video.NumberOfComments] = video.NumberOfComments.ToString();
                item[FieldNames.Video.NumberFavorited] = video.NumberFavorited.ToString();
                item[FieldNames.Video.NumberShared] = video.NumberShared.ToString();
            }
            return item;
        }
    }
}
