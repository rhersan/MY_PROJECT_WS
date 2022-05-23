using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MyProject.Models.Logs
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Error { get; set; }

        public int ErrorNumber { get; set; }

        public string FileName { get; set; }

        public DateTime DateLog { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUser { get; set; }

        public string Platform { get; set; }

        public int LineNumber { get; set; }

        public Log()
        {
            DateLog = DateTime.Now;
            _id = ObjectId.GenerateNewId().ToString();
            Platform = "WS";
        }

    }
}
