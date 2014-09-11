namespace WPFexample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDB;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;

    public class MongoDatabaseProvider
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "Logger";

        public class Log
        {
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            public string User { get; set; }

            public string Text { get; set; }

            public DateTime LogDate { get; set; }

            public Log(string username, string text, DateTime logDate)
            {
                this.Id = ObjectId.GenerateNewId().ToString();
                this.User = username;
                this.Text = text;
                this.LogDate = logDate;
            }
        }

        public class Message
        {
            public string User { get; set; }
            public string Text { get; set; }
            public string Date { get; set; }
        }

        public static MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            MongoServer server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        public static IList<Message> SendMessage(string username, string textmessage)
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);
            var logs = db.GetCollection<Log>("Logs");

            logs.Insert(new Log(username, textmessage, DateTime.Now));
            var allLogs = logs.FindAll()
                .Select(l => new Message()
                {
                    User = l.User.ToString(),
                    Text = l.Text.ToString(),
                    Date = l.LogDate.Date.ToString()
                }).ToList();
            return allLogs;
        }
    }
}
