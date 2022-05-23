using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class ProductDAL : BaseDAL
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> GetProductsById(int id)
        {
            return db.Products.Where(x => x.id == id).ToList();
        }

        public Product CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            //db.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyProduct(int id)
        {
            return db.Products.Any(x => x.id == id);
        }

    }
}