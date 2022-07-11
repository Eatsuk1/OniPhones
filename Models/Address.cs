using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DoAn1.Models
{
    public class Address
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Tỉnh Thành Phố")]
        public string city_province { get; set; }

        [BsonElement("Mã TP")]
        public string cp_code { get; set; }
        [BsonElement("Quận Huyện")]
        public string district { get; set; }

        [BsonElement("Mã QH")]
        public string d_code { get; set; }

        [BsonElement("Phường Xã")]
        public string ward { get; set; }

        [BsonElement("Mã PX")]
        public string ward_code { get; set; }

        [BsonElement("Cấp")]
        public string ward_level { get; set; }
    }
}
