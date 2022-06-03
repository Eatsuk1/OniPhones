using MongoDB.Driver;

namespace DoAn1.Service
{
    public class ClassDB
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        public IMongoDatabase GetConnection()
        {
            _client = new MongoClient("mongodb+srv://anhlee:xV7YI1Ztks9hxBYN@demo.d96zs.mongodb.net/?retryWrites=true&w=majority");
            return _database = _client.GetDatabase("cphones");   
        }
    }
}
