using DoAn1.Data;
using Microsoft.AspNetCore.Components.Authorization;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Security.Claims;
using System.Threading.Tasks;



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

       

        public Customer GetCustomer(string Customerid)
        {
            
            var filter = Builders<Customer>.Filter.Eq(x => x.UserId, Customerid);
            var projection = Builders<Customer>.Projection.Include("name").Include("joined day");
            return BsonSerializer.Deserialize<Customer>(_collection.Find(filter).Project(projection).FirstOrDefault());


        }

        public Customer GetCustomerAddress(string customerid)
        {
            var filter = Builders<Customer>.Filter.Eq(x=> x.UserId, customerid);
            var projection = Builders<Customer>.Projection.Include("address");

            return BsonSerializer.Deserialize<Customer>(_collection.Find(filter).Project(projection).FirstOrDefault());
            
        }
    }
}
