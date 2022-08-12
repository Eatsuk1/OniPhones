using System;
using DoAn1.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoAn1.Service
{
    public class OrderService
    {
        private readonly ClassDB db = new();
        private IMongoCollection<Order> _collection;

        public OrderService()
        {
            _collection = db.GetConnection().GetCollection<Order>("order");
        }

        public async Task AddNewOrder(string _user_id, string _cus_name, string _cus_email, string _cus_phone_number, string _payment_method, string _shipping_address, string _shipping_method, int _shipping_fee, List<product_order> _product_order, int _total_price)
        {
            var document = new Order
            {
                user_id = _user_id,
                cus_name = _cus_name,
                cus_email = _cus_email,
                cus_phone_number = _cus_phone_number,
                payment_method = _payment_method,
                shipping_address = _shipping_address,
                shipping_method = _shipping_method,
                shipping_fee = _shipping_fee,
                product_order = _product_order,
                created_on_date = DateTime.Now.ToShortDateString(),
                created_on_time = DateTime.Now.ToShortTimeString(),
                total_price = _total_price,
                status = "Đang xác nhận",
            };
            await _collection.InsertOneAsync(document);
        }

        public List<Order> GetOrderHis(string _user_id)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.user_id, _user_id);
            return _collection.Find(filter).ToList();
        }
    }
}
