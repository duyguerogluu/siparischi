using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class ProductRatingDAL : BaseDAL
    {
            public IEnumerable<ProductRating> GetAllProductRatings()
            {
                return db.ProductRatings.ToList();
            }

            public IEnumerable<ProductRating> GetProductRatingsById(int id)
            {
                return db.ProductRatings.Where(x => x.id == id).ToList();
            }

        public String GetProductRatingsByCategoryIdAverage(int productId)
        {
            var rating = db.ProductRatings.Where(x => x.product_id == productId).Select(x => x.point_value).Average();
            return rating.ToString();
        }

        public ProductRating CreateProductRating(ProductRating productRating)
            {
                db.ProductRatings.Add(productRating);
                db.SaveChanges();
                return productRating;
            }

            public ProductRating UpdateProductRating(ProductRating productRating)
            {
                db.Entry(productRating).State = EntityState.Modified;
                //db.SaveChanges();
                return productRating;
            }

            public void DeleteProductRating(int id)
            {
                db.ProductRatings.Remove(db.ProductRatings.Find(id));
                db.SaveChanges();
            }

            public bool IsThereAnyProductRating(int id)
            {
                return db.ProductRatings.Any(x => x.id == id);
            }

        }
    }