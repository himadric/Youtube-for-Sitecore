using System.Collections;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;
using Sitecore.MediaFramework.Import;
using Sitecore.MediaFramework.Youtube.Security;
using System;
using System.Collections.Generic;
using System.Text;
using Sitecore.Diagnostics;

namespace Sitecore.MediaFramework.Youtube.Import
{
    public class VideoImporter : IImportExecuter
    {
        public IEnumerable<object> GetData(Data.Items.Item accountItem)
        {
            if (YoutubeAuthenticator.youtubeService != null)
            {
                //Create the items
                var videos = GetVideos().Result;
                return videos;
            }
            return null;
        }

        private async Task<IEnumerable<PlaylistItem>> GetVideos()
        {
            IEnumerable<PlaylistItem> playList = new List<PlaylistItem>();
            var channelsListRequest = YoutubeAuthenticator.youtubeService.Channels.List("contentDetails");
            channelsListRequest.Mine = true;

            // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
            var channelsListResponse = await channelsListRequest.ExecuteAsync();

            foreach (var channel in channelsListResponse.Items)
            {
                // From the API response, extract the playlist ID that identifies the list
                // of videos uploaded to the authenticated user's channel.
                var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;

                var nextPageToken = string.Empty;
                while (nextPageToken != null)
                {
                    var playlistItemsListRequest = YoutubeAuthenticator.youtubeService.PlaylistItems.List("snippet");
                    playlistItemsListRequest.PlaylistId = uploadsListId;
                    playlistItemsListRequest.MaxResults = 50;
                    playlistItemsListRequest.PageToken = nextPageToken;

                    // Retrieve the list of videos uploaded to the authenticated user's channel.
                    var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
                    foreach (var playlistItem in playlistItemsListResponse.Items)
                    {
                        // Print information about each video.
                        //playList.Add(playlistItem);
                    }

                    nextPageToken = playlistItemsListResponse.NextPageToken;
                }
            }
            return playList;
        }
    }
}
