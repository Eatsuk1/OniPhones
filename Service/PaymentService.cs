using DoAn1.Models;
using MongoDB.Driver;
using System.Collections.Generic;

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

        public List<Address> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

    }
}
