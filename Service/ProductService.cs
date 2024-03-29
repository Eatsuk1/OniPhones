﻿using DoAn1.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoAn1.Service
{
    public class ProductService
    {
        private readonly ClassDB db = new();
        private IMongoCollection<Smartphone> _collection;

        public ProductService()
        {
            _collection = db.GetConnection().GetCollection<Smartphone>("smartphone");
        }

        public List<Smartphone> GetSmartphones()
        {
            return _collection.Find(_ => true).Limit(5).ToList();
        }

        public List<Smartphone> GetSmartphonesFilter(string _key)
        {
            var filter = Builders<Smartphone>.Filter.Regex("key", new BsonRegularExpression(_key, "imxs"));
            return _collection.Find(filter).ToList();
        }



        public Smartphone GetSpecifySmartphone(string _key)
        {
            var filter = Builders<Smartphone>.Filter.Eq("key", _key);
            return _collection.Find(filter).FirstOrDefault();
        }

    }
}
