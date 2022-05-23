using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MyProject.Models.Common
{
    public class BaseUpdateCreate
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUserCreation { get; set; }

        [BsonIgnoreIfNull]
        public DateTime? CreationDate { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUserUpdate { get; set; }

        public int? Status { get; set; }
        [BsonIgnoreIfNull]
        public DateTime? UpdateDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnore]
        public string IdUser { get; set; }
    }
}
