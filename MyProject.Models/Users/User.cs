using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MyProject.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Users
{
    public  class User: BaseUpdateCreate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MotherLastName { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string Sex { get; set; }

        public string Email { get; set; }

        public string PhotoPath { get; set; }

        public string Phone { get; set; }

        [BsonIgnore]
        public string Token { get; set; }

    }
}
