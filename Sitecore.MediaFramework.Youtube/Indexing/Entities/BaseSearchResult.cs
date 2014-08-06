using Sitecore.ContentSearch;
using Sitecore.MediaFramework.Entities;

namespace Sitecore.MediaFramework.Youtube.Indexing.Entities
{
    public class BaseSearchResult : MediaServiceSearchResult
    {
        [IndexField("id")]
        public string Id { get; set; }
        [IndexField("title")]
        public string Title { get; set; }
        [IndexField("description")]
        public string Description { get; set; }
        [IndexField("channelname")]
        public string ChannelName { get; set; }
    }
}
