using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.MediaFramework.Youtube
{
    public static class FieldNames
    {
        public static class Account
        {
            public static readonly string ClinetId = "ClientId";
            public static readonly string ClientSecret = "ClientSecret";

            static Account()
            {
            }
        }

        public static class AccountSettings
        {
            public static readonly string DefaultVideoPlayer = "DefaultVideoPlayer";
            public static readonly string DefaultPlaylistPlayer = "DefaultPlaylistPlayer";

            static AccountSettings()
            {
            }
        }

        public static class MediaElement
        {
            public static readonly string Id = "Id";
            public static readonly string Title = "Title";
            public static readonly string Description = "Description";
            public static readonly string ChannelName = "Channel Name";

            static MediaElement()
            {
            }
        }

        public static class Video
        {
            public static readonly string VideoUrl = "VideoUrl";
            public static readonly string StillImageUrl = "StillImageUrl";
            public static readonly string ThumbnailUrl = "ThumbnailUrl";
            public static readonly string UploadDate = "UploadDate";
            public static readonly string VideoFileName = "VideoFileName";
            public static readonly string Views = "Views";
            public static readonly string Likes = "Likes";
            public static readonly string Dislikes = "Dislikes";
            public static readonly string NumberOfComments = "NumberOfComments";
            public static readonly string NumberFavorited = "NumberFavorited";
            public static readonly string NumberShared = "NumberShared";

            static Video()
            {
            }
        }

        public static class PlayerList
        {
            public static readonly string PlayListUrl = "PlayListUrl";
            public static readonly string Privacy = "Privacy";

            static PlayerList()
            {
            }
        }

        public static class Player
        {
            public static readonly string Id = "Id";
            public static readonly string BackgroundColor = "Background Color";
            public static readonly string WMode = "Window Mode";

            static Player()
            {
            }
        }
    }
}
