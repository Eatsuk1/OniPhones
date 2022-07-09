using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DoAn1.Models
{
    public class SubHeader
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Device_Type   { get; set; }

        public List<string> Device_key { get; set; }

        public string Series { get; set; }
    }
}
