using MongoDB.Driver;

namespace DoAn1.Service
{
    public class ClassDB
    {
        private MongoClient _client;
        public IMongoDatabase GetConnection()
        {
            _client = new MongoClient("mongodb+srv://anhlee:baC2ZBW3eGN2WCgS@demo.d96zs.mongodb.net/?retryWrites=true&w=majority");
            return _client.GetDatabase("cphones");
        }
    }
}
