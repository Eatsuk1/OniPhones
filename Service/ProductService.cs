using DoAn1.Data;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DoAn1.Service
{
	public class ProductService
	{
		ClassDB db = new ClassDB();
		private IMongoCollection<Smartphone> _collection;

		public ProductService()
		{
			_collection = db.GetConnection().GetCollection<Smartphone>("smartphone");
		}

		public List<Smartphone> GetSmartphones()
		{

			return _collection.Find(_ => true).Limit(5).ToList();
		}
	}
}
