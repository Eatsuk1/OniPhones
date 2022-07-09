using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DoAn1.Data
{
    public class Smartphone
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string key { get; set; }

        public string device_name { get; set; }

        public string device_image { get; set; }
        public string display_size { get; set; }
        public string display_res { get; set; }
        public string camera { get; set; }
        public string video { get; set; }
        public string ram { get; set; }
        public string chipset { get; set; }
        public string battery { get; set; }
        public string batteryType { get; set; }
        public string body { get; set; }
        public string os_type { get; set; }
        public string storage { get; set; }

        public string default_price { get; set; }

        public List<string> pictures { get; set; }


        public Price prices;

    }

    public class Price
    {
        public string p128GB { get; set; }

        public string p256GB { get; set; }

        public string p512GB { get; set; }
    }
}
