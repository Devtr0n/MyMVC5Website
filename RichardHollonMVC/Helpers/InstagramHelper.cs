using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace RichardHollonMVC.Helpers
{
    public class InstagramHelper
    {
        public static InstagramImage[] GetInstagramFeed() 
        {            
            //declare the variables we need to get this Instagram feed working.
            List<InstagramImage> feed = new List<InstagramImage>();
            HttpWebRequest request = null;
            Stream responseStream = null;
            String nextPageUrl = null;
            JToken pagination = null;
            JToken token = null;

            do
            {
                //see if we already have a "nextPageUrl" from Instragram's API
                if (string.IsNullOrEmpty(nextPageUrl))
                    request = (HttpWebRequest)HttpWebRequest.Create("https://api.instagram.com/v1/users/188067182/media/recent?count=33&access_token=" + ConfigurationManager.AppSettings["instagramAccessToken"]);
                else
                    request = (HttpWebRequest)HttpWebRequest.Create(nextPageUrl);

                //get Instagram's response to our request
                responseStream = request.GetResponse().GetResponseStream();
                Encoding encode = System.Text.Encoding.Default;

                using (StreamReader reader = new StreamReader(responseStream, encode))
                {
                    token = JObject.Parse(reader.ReadToEnd());
                    pagination = token.SelectToken("pagination");

                    //get the URL for our next request, for the next set of images!
                    if (pagination != null && pagination.SelectToken("next_url") != null)
                    {
                        nextPageUrl = pagination.SelectToken("next_url").ToString();
                    }
                    else
                    {
                        nextPageUrl = null; //no more images, we got them all already! well done, bravo!
                    }

                    //get JSON results from the response and parse them
                    dynamic results = Newtonsoft.Json.JsonConvert.DeserializeObject(token.ToString());                    

                    //iterate through the results and aggregate them to our feed object
                    foreach (var data in results.data)
                    {
                        InstagramImage image = new InstagramImage();

                        try
                        {
                            image.Caption = data.caption.text;
                            image.URL = data.images.thumbnail.url;
                            image.Tags = data.tags ?? null;
                            image.Link = data.link;
                            image.isPublic = true;

                            //Debug.WriteLine("Tags found: " + image.Tags.Count.ToString());

                            //inspect the Instagram image tags
                            foreach (String tag in image.Tags)
                            {
                                //filter out "beer" pictures
                                if (tag.Equals("beer") || tag.Equals("sourbeer"))
                                {
                                    image.isPublic = false;
                                }
                            }

                            //add the Instagram image to the output feed
                            if (image.isPublic)
                            {
                                feed.Add(image);
                            }
                        }
                        catch
                        {
                            image.Caption = String.Empty;
                            image.URL = String.Empty;
                            image.Tags = null;
                            image.isPublic = false;
                        }                     
                     
                    }
                }
            }
            while (!String.IsNullOrEmpty(nextPageUrl));

            return feed.ToArray();
        }

        public class InstagramImage
        {
            public string Link { get; set; }
            public string Caption { get; set; }
            public string URL { get; set; }
            public JArray Tags { get; set; }
            public bool isPublic { get; set; }
        }

    }
}