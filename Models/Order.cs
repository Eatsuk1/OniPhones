using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DoAn1.Models
{
    public class Order
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string cus_email { get; set; }

        public string cus_name { get; set; }
        
        public string cus_phone_number { get; set; }

        public string payment_method { get; set; }

        public string shipping_address { get; set; }
        
        public string shipping_method { get; set; }

        public string user_id { get; set; }

        public string shipping_fee { get; set; }

        public string created_on_date { get; set; }

        public string created_on_time { get; set; }

        public List<product_order> product_order { get; set; }
    }

    public class product_order
    {
        public string device_key { get; set; }
        
        public int quantity { get; set; }

        public int sub_price { get; set; }
    }
}
