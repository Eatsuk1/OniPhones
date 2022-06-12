using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;   

namespace DoAn1.Data
{

    public class Customer
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("user_id")]
        public string UserId { get; set; }      

        [BsonElement("name")]
        public string Name { get; set; }

        
        public List<string> address { get; set; }

        [BsonElement("joined day")]
        public string JoinedDay { get; set; }
        [BsonElement("phone number")]
        public string PhoneNumber { get; set; }
        [BsonElement("birthday")]
        public string Birthday { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }

    }

   
   
}
