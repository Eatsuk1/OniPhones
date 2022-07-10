using DoAn1.Data;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DoAn1.Service
{
    public class CustomerService
    {
        private readonly ClassDB db = new ClassDB();
        private IMongoCollection<Customer> _collection;



        public CustomerService()
        {
            _collection = db.GetConnection().GetCollection<Customer>("customers");
        }

        public bool VerifyCustomer(string customerid)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.UserId, customerid);
            if (_collection.Find(filter).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task AddCustomer(string _customerid, string _name, string _email)
        {
            var document = new Customer();
            document.UserId = _customerid;
            document.Name = _name;
            document.Email = _email;
            document.Birthday = "";
            document.JoinedDay = DateTime.Today.ToShortDateString();
            document.PhoneNumber = "";
            document.address = new List<string>() { "" };
            await _collection.InsertOneAsync(document);
        }

        public Customer GetCustomer(string Customerid)
        {

            var filter = Builders<Customer>.Filter.Eq(x => x.UserId, Customerid);
            var projection = Builders<Customer>.Projection.Include("name").Include("joined day");
            return BsonSerializer.Deserialize<Customer>(_collection.Find(filter).Project(projection).FirstOrDefault());
        }

        public Customer GetCustomerAddress(string customerid)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.UserId, customerid);
            var projection = Builders<Customer>.Projection.Include("address");

            return BsonSerializer.Deserialize<Customer>(_collection.Find(filter).Project(projection).FirstOrDefault());

        }

        public Customer GetCustomerInfoPayment(string customerid)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.UserId, customerid);
            return _collection.Find(filter).FirstOrDefault();
        }
    }
}
