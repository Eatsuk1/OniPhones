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

        public List<string> GetDistrict(string _city)
        {
            var filter = Builders<Address>.Filter.Eq(x => x.city_province, _city);
            return _collection.Distinct(x => x.district, filter).ToList();
        }

        public List<string> GetWard(string _district)
        {
            var builder = Builders<Address>.Filter;
            var filter = builder.Eq(x => x.district, _district);
            return _collection.Distinct(x => x.ward, filter).ToList();
        }
    }
}
