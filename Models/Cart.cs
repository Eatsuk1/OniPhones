using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DoAn1.Models
{
    public class Cart
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string device_key { get; set; }

        public int quantity { get; set; }

        //public int subtotal { get; set; }

        //public string ShippingAddress { get; set; }

        //public int ShippingCharges { get; set; }

        //public string PaymentMode  { get; set; }

        public string user_id { get; set; }
    }
}
