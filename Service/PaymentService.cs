using DoAn1.Models;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoAn1.Service
{
    public class PaymentService
    {
        private readonly ClassDB db = new();
        private IMongoCollection<Address> _collection;

        public PaymentService()
        {
            _collection = db.GetConnection().GetCollection<Address>("address");
        }

        public List<string> GetCity()
        {
            var filter = Builders<Address>.Filter.Empty;
            return _collection.Distinct(x => x.city_province,filter).ToList();
        }

        
    }
}
