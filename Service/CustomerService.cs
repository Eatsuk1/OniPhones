using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using DoAn1.Data;

namespace DoAn1.Service
{
    public class CustomerService
    {
        private ClassDB db = new ClassDB();
        private IMongoCollection<Customer> _collection;
        

        public CustomerService()
        {

            _collection = db.GetConnection().GetCollection<Customer>("customers");
        }

        

        public Customer GetCustomer(string customerid)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, customerid);
            var projection = Builders<Customer>.Projection.Include("name").Include("joined day");
            return BsonSerializer.Deserialize<Customer>(_collection.Find(filter).Project(projection).FirstOrDefault());


        }

        public Customer GetCustomerAddress(string customerid)
        {
            var filter = Builders<Customer>.Filter.Eq(x=> x.Id, customerid);
            var projection = Builders<Customer>.Projection.Include("address");

            return BsonSerializer.Deserialize<Customer>(_collection.Find(filter).Project(projection).FirstOrDefault());
            
        }
    }
}
