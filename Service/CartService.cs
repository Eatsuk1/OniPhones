using DoAn1.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DoAn1.Service
{
    public class CartService
    {
        ClassDB db = new ClassDB();
        private IMongoCollection<Cart> _collection;

        public CartService()
        {
            _collection = db.GetConnection().GetCollection<Cart>("cart");
        }

        public async Task AddtoCart(string _key, string _user_id, int _quantity)
        {
            var document = new Cart();
            document.device_key = _key;
            document.user_id = _user_id;
            document.quantity = _quantity;
            await _collection.InsertOneAsync(document);
        }

        public bool CheckDup(string _key, string _user_id)
        {
            var builder = Builders<Cart>.Filter;
            var filter = builder.And(builder.Eq("device_key", _key), builder.Eq("user_id", _user_id));
            if (_collection.Find(filter).FirstOrDefault() != null)
            {
                var update = Builders<Cart>.Update.Set("quantity", _collection.Find(filter).FirstOrDefault().quantity+=1);
                _collection.UpdateOne(filter, update);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Cart> GetCart(string _user_id)
        {
            var filter = Builders<Cart>.Filter.Eq(x => x.user_id, _user_id);
            return _collection.Find(filter).ToList();
        }

        public async Task UpdateCart(string _key, string _user_id, int _quantity)
        {
            var builder = Builders<Cart>.Filter;
            var filter = builder.And(builder.Eq("device_key", _key), builder.Eq("user_id", _user_id));
            var update = Builders<Cart>.Update.Set("quantity", _collection.Find(filter).FirstOrDefault().quantity=_quantity);
            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
