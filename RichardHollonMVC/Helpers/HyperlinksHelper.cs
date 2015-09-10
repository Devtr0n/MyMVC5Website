using System.Collections.Generic;
using System.Web;
using System.IO;

namespace RichardHollonMVC.Helpers
{
    public class HyperlinksHelper
    {
        public class FavoriteHyperlink
        {
            public List<FavoriteHyperlink> items { get; set; }
            public string Title { get; set; }
            public string URL { get; set; }
        }
        
        public static FavoriteHyperlink[] GetRandomizedHyperlinks()
        {
            string path = HttpContext.Current.Server.MapPath("~/Content/Hyperlinks.json");
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                var links = (FavoriteHyperlink)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(FavoriteHyperlink));

                return links.items.ToArray();
            }           

        }
    }
}