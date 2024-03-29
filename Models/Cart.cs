﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DoAn1.Models
{
    public class Cart
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string device_key { get; set; }

        public int quantity { get; set; }
        
        public string storage_version { get; set; }

        public string color_selected { get; set; }

        public string user_id { get; set; }
    }
}
