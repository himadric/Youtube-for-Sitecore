using System;
using Sitecore.MediaFramework.Entities;
using Sitecore.MediaFramework.Synchronize.Fallback;
using Sitecore.MediaFramework.Youtube.Indexing.Entities;

namespace Sitecore.MediaFramework.Youtube.Synchronize.Fallback
{
    public abstract class BaseFallBack<T> : DatabaseFallbackBase where T : BaseSearchResult, new()
    {
        protected override MediaFramework.Entities.MediaServiceSearchResult GetSearchResult(Data.Items.Item item)
        {
            T instance = Activator.CreateInstance<T>();
            instance.Id = item[FieldNames.MediaElement.Id];
            instance.Title = item[FieldNames.MediaElement.Title];
            instance.Description = item[FieldNames.MediaElement.Description];
            instance.ChannelName = item[FieldNames.MediaElement.ChannelName];
            return (MediaServiceSearchResult)instance;
        }
    }
}
