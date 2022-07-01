using DoAn1.Data;
using DoAn1.Models;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DoAn1.Service
{
    public class SubHeaderService
    {
        ClassDB db = new ClassDB();
        private IMongoCollection<SubHeader> _collection;

        public SubHeaderService()
        {
            _collection = db.GetConnection().GetCollection<SubHeader>("category");
        }

        public SubHeader GetSubHeader(string _device_key)
        {
            var filter = Builders<SubHeader>.Filter.AnyEq(x => x.Device_key, _device_key);
            var projection = Builders<SubHeader>.Projection.Include("Brand").Include("Device_Type").Include("Series");
            return BsonSerializer.Deserialize<SubHeader>(_collection.Find(filter).Project(projection).FirstOrDefault());
        }
    }
}
