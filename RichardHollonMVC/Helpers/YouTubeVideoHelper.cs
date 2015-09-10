//using Google.GData.Client;
//using Google.YouTube;
using System;
using System.Linq;

namespace RichardHollonMVC.Helpers
{
    public class YouTubeVideoHelper
    {
        const string YOUTUBE_CHANNEL = "Blueberryfarm";
        const string YOUTUBE_DEVELOPER_KEY = "xxxx";
        const string YOUTUBE_VIDEO_TOTAL_COUNT = "50"; //total number of videos to pull from my Youtube channel
        
        //TO-DO: replace Youtube API with XML parser!!
        //https://www.youtube.com/feeds/videos.xml?user=blueberryfarm
        
        //public static YouTubeVideoObject[] GetVideos()
        //{
        //    YouTubeRequestSettings settings = new YouTubeRequestSettings(YOUTUBE_CHANNEL, YOUTUBE_DEVELOPER_KEY);
        //    YouTubeRequest request = new YouTubeRequest(settings);
        //    string feedUrl = String.Format("http://gdata.youtube.com/feeds/api/users/{0}/uploads?max-results={1}&orderby=published", YOUTUBE_CHANNEL, YOUTUBE_VIDEO_TOTAL_COUNT);
        //    Feed<Video> videoFeed = request.Get<Video>(new Uri(feedUrl));
        //    return (from video in videoFeed.Entries
        //            select new YouTubeVideoObject() { VideoId = video.VideoId, Title = video.Title }).ToArray();
        //}
    }

    public class YouTubeVideoObject
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
    }

}
