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


        public List<string> GetCustomerAddress(string customerid)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.UserId, customerid);
            var projection = Builders<Customer>.Projection.Include("address");

            return BsonSerializer.Deserialize<Customer>(_collection.Find(filter).Project(projection).FirstOrDefault()).address;

        }

        public Customer GetCustomerInfo(string customerid)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.UserId, customerid);
            return _collection.Find(filter).FirstOrDefault();
        }

        public async Task AddNewAddress(string _city, string _district, string _ward, string _detail, string _customerid)
        { 
            var document = _detail+", "+_ward+", "+_district+", "+_city;
            var filter = Builders<Customer>.Filter.Eq(x => x.UserId, _customerid);
            var update = Builders<Customer>.Update.Push(x=>x.address, document);
            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task UpdateAddress(string _oldaddress, string _newaddress, string _customerid)
		{
            var builder = Builders<Customer>.Filter;
            var filter = builder.And(builder.Eq(x => x.UserId, _customerid), builder.ElemMatch(x => x.address, _oldaddress));
            var update = Builders<Customer>.Update.Set(x => x.address[-1], _newaddress);
            await _collection.UpdateOneAsync(filter, update);

		}

        public async Task DeleteAddress(string _address, string _customerid)
		{
            var filter = Builders<Customer>.Filter.Eq(x => x.UserId, _customerid);
            var update = Builders<Customer>.Update.PullFilter(x => x.address, _address);
            await _collection.UpdateOneAsync(filter, update);
		}
    }
}
