using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyProject.Models
{
    /// <summary>
    /// Clase
    /// </summary>
    public class BaseModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
    }

}
