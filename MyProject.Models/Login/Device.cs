using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MyProject.Models.Login
{
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string DeviceId { get; set; }
        public int Status { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUserCreation { get; set; }

        public DateTime CreationDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUserUpdate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
