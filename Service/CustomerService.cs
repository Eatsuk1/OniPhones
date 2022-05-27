using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using DoAn1.Data;

namespace DoAn1.Service
{
    public class CustomerService
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Customer> _collection;
        public string CustomerId { get; set; } = "627e792d5571cc484d050b6e";



        public CustomerService()
        {
            _client = new MongoClient("mongodb+srv://anhlee:xV7YI1Ztks9hxBYN@demo.d96zs.mongodb.net/?retryWrites=true&w=majority");
            _database = _client.GetDatabase("cphones");
            _collection = _database.GetCollection<Customer>("customers");
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
