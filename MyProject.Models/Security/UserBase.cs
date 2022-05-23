using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyProject.Models.Security
{
    public class UserBase
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int? CompanyId { get; set; }
        public int? UserRoleId { get; set; }
        public int? IsRoleSupervisor { get; set; }
        public string Token { get; set; }
        public string UserPassword { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}
