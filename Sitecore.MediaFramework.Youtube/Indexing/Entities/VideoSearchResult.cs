using Sitecore.ContentSearch;
namespace Sitecore.MediaFramework.Youtube.Indexing.Entities
{
    public class VideoSearchResult : BaseSearchResult
    {
        [IndexField("videourl")]
        public string VideoUrl { get; set; }
        [IndexField("stillimageurl")]
        public string StillImageUrl { get; set; }
        [IndexField("thumbnailurl")]
        public string ThumbnailUrl { get; set; }
        [IndexField("uploaddate")]
        public string UploadDate { get; set; }
        [IndexField("videofilename")]
        public string VideoFileName { get; set; }
        [IndexField("numberofviews")]
        public string NumberOfViews { get; set; }
        [IndexField("numberoflikes")]
        public string NumberOfLikes { get; set; }
        [IndexField("numberofdislikes")]
        public string NumberOfDislikes { get; set; }
        [IndexField("numberofcomments")]
        public string NumberOfComments { get; set; }
        [IndexField("numberfavorited")]
        public string NumberFavorited { get; set; }
        [IndexField("numbershared")]
        public string NumberShared { get; set; }
    }
}
