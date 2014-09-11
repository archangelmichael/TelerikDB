namespace _01.UsingRSSfeed
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Xml.Linq;
    using FeedObjects;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /*
     * Using JSON.NET and the Telerik Academy Forums RSS feed implement the following:
     * 1. The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss
     * 2. Download the content of the feed programmatically. You can use WebClient.DownloadFile()
     * 3. Parse the XML from the feed to JSON
     * 4. Using LINQ-to-JSON select all the question titles and print them to the console
     * 5. Parse the JSON string to POCO
     * 6. Using the parsed objects create a HTML page 
     * that lists all questions from the RSS their categories and a link to the question's page
     * */
    public class Program
    {
        private const string RSSfeed = @"http://forums.academy.telerik.com/feed/qa.rss";

        private const string XMLOutputPath = @"../../feed.xml";

        private const string JSONOutputPath = @"../../feed.json";
        
        private const string HTMLOutputPath = @"../../feed.html";

        private const string PageStart = "<body>\n\t<ul>\n";

        private const string ListItemFormat = "\t\t<li>Question : {0} <br /> Category : {1} <br /> Link : {2} </li>";

        private const string PageEnd = "\t</ul>\n</body>";

        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

            //// TASK 1 AND 2
            DownloadFeed();

            //// TASK 3
            var jsonObjects = CreateJSONFromXML();

            //// TASK 4
            PrintQuestionTitles(jsonObjects);

            //// TASK 5
            var pocoObjects = ParseJSONtoPOCO(jsonObjects);
            foreach (var item in pocoObjects.Rss.Channel.Item)
            {
                Console.WriteLine(item.Title);
            }

            //// TASK 6
            CreateHTMLFromJSON(HTMLOutputPath, pocoObjects);
        }

        private static void CreateHTMLFromJSON(string path, Root pocoObjects)
        {
            StringBuilder html = new StringBuilder(PageStart);
            foreach (var item in pocoObjects.Rss.Channel.Item)
            {
                html.AppendLine(string.Format(ListItemFormat, item.Title, item.Category, item.Link));
            }

            html.AppendLine(PageEnd);
            CreateFile(html.ToString(), path);
        }

        private static void CreateFile(string html, string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    writer.WriteLine(html);
                }
            }
        }

        private static Root ParseJSONtoPOCO(string jsonObjects)
        {
            return JsonConvert.DeserializeObject<Root>(jsonObjects);
        }

        private static void PrintQuestionTitles(string jsonObjects)
        {
            JObject jsonObj = JObject.Parse(jsonObjects);
            foreach (var item in jsonObj["rss"]["channel"]["item"])
            {
                Console.WriteLine(item["title"]);
            }
        }

        private static string CreateJSONFromXML()
        {
            var xmlNode = XElement.Load(XMLOutputPath);
            string xmlToJson = JsonConvert.SerializeXNode(xmlNode, Newtonsoft.Json.Formatting.Indented);
            CreateFile(xmlToJson, JSONOutputPath);
            return xmlToJson;
        }

        private static void DownloadFeed()
        {
            var webclient = new WebClient();
            webclient.DownloadFile(RSSfeed, XMLOutputPath);
        }
    }
}
