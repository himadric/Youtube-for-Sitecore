using Sitecore.Data;

namespace Sitecore.MediaFramework.Youtube
{
    public class FieldIDs
    {
        public static class Account
        {
            public static readonly ID ClinetId = new ID("{02283FAF-B186-4DC8-AEF1-809C4089B605}");
            public static readonly ID ClientSecret = new ID("{BF3B5662-3001-4241-9266-E7962D2FBB80}");

            static Account()
            {
            }
        }

        public static class AccountSettings
        {
            public static readonly ID DefaultVideoPlayer = new ID("{7D094DA9-D055-42CC-BE06-15EC496BDD3D}");
            public static readonly ID DefaultPlaylistPlayer = new ID("{DB35F472-783C-42BA-9EA2-5D3DBA829D1C}");

            static AccountSettings()
            {
            }
        }

        public static class MediaElement
        {
            public static readonly ID Id = new ID("{A559DAD4-C83E-4D40-B031-306D5F54FBC8}");
            public static readonly ID Title = new ID("{C9B249A8-F165-4C9D-83DE-42D3F6A59D29}");
            public static readonly ID Description = new ID("{5C8296CB-AC88-4BA6-B171-1CD429AD8A70}");
            public static readonly ID ChannelName = new ID("{20090BCE-9A82-4300-946F-BE686E14CA08}");

            static MediaElement()
            {
            }
        }

        public static class Video
        {
            public static readonly ID VideoUrl = new ID("{90BA0EBD-D7E1-468A-B0A4-B9DB736A3FCB}");
            public static readonly ID StillImageUrl = new ID("{FCCC6A6B-DA41-4B2A-9D13-31C4445B098D}");
            public static readonly ID ThumbnailUrl = new ID("{DB22AFD2-A507-469A-83E9-DA9B291F6283}");
            public static readonly ID UploadDate = new ID("{DB63A97D-12A8-4E0F-A557-420B3EFBBDCC}");
            public static readonly ID VideoFileName = new ID("{E69B3D37-1B3A-406C-A735-1D5974513AFA}");
            public static readonly ID Views = new ID("{4A65645D-39E1-44C9-A514-18CA6F331BAE}");
            public static readonly ID Likes = new ID("{4D8C9814-4D5C-43B3-AC91-661CE35431CA}");
            public static readonly ID Dislikes = new ID("{EDC7724D-1E52-4D98-80CB-70493EE6FCAB}");
            public static readonly ID NumberOfComments = new ID("{BA4CDD93-7490-4032-B73F-CC077DA75F14}");
            public static readonly ID NumberFavorited = new ID("{849C22C6-3D2C-4030-8CF8-CFD57C651D5A}");
            public static readonly ID NumberShared = new ID("{79BEAA8C-A383-4BBB-86ED-45E0DE2863C6}");

            static Video()
            {
            }
        }

        public static class PlayerList
        {
            public static readonly ID PlayListUrl = new ID("{9F6AD734-E783-4EB0-B1A1-C0EFE70A8329}");
            public static readonly ID Privacy = new ID("{CA8C3961-C880-4AF9-92E3-7D0DBE56B90E}");

            static PlayerList()
            {
            }
        }

        public static class Player
        {
            public static readonly ID Id = new ID("{483DA6F4-4B21-4017-9803-979D3D89135E}");
            public static readonly ID BackgroundColor = new ID("{7883F6E6-849D-4793-AA39-BA5AB98B46DC}");
            public static readonly ID WMode = new ID("{70D30104-2FE0-4113-9B9B-7B0BAB2BB8C4}");
            public static readonly ID Height = new ID("{1EAB38DD-CCBA-4FAE-84B9-F192EC124682}");
            public static readonly ID Width = new ID("{40B6BE4B-158C-4150-B5D8-034CF9B676F6}");

            static Player()
            {
            }
        }

    }
}
