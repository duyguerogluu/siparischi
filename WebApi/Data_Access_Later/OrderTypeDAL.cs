using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class OrderTypeDAL : BaseDAL
    {
        public IEnumerable<OrderType> GetAllOrderTypes()
        {
            return db.OrderTypes.ToList();
        }

        public IEnumerable<OrderType> GetOrderTypesById(int id)
        {
            return db.OrderTypes.Where(x => x.id == id).ToList();
        }

        public OrderType CreateOrderType(OrderType orderType)
        {
            db.OrderTypes.Add(orderType);
            db.SaveChanges();
            return orderType;
        }

        public OrderType UpdateOrderType(OrderType orderType)
        {
            db.Entry(orderType).State = EntityState.Modified;
            //db.SaveChanges();
            return orderType;
        }

        public void DeleteOrderType(int id)
        {
            db.OrderTypes.Remove(db.OrderTypes.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyOrderType(int id)
        {
            return db.OrderTypes.Any(x => x.id == id);
        }
    }
}