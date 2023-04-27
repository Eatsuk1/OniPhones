using MongoDB.Driver;

namespace DoAn1.Service
{
    public class ClassDB
    {
        private MongoClient _client;
        public IMongoDatabase GetConnection()
        {
            _client = new MongoClient("");
            return _client.GetDatabase("cphones");
        }
    }
}
