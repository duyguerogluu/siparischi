using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class BusinessRatingDAL : BaseDAL
    {
        public IEnumerable<BusinessRating> GetAllBusinessRatings()
        {
            return db.BusinessRatings.ToList();
        }

        public IEnumerable<BusinessRating> GetBusinessRatingsById(int id)
        {
            return db.BusinessRatings.Where(x => x.id == id).ToList();
        }

        public BusinessRating CreateBusinessRating(BusinessRating businessRating)
        {
            db.BusinessRatings.Add(businessRating);
            db.SaveChanges();
            return businessRating;
        }

        public BusinessRating UpdateBusinessRating(BusinessRating businessRating)
        {
            db.Entry(businessRating).State = EntityState.Modified;
            //db.SaveChanges();
            return businessRating;
        }

        public void DeleteBusinessRating(int id)
        {
            db.BusinessRatings.Remove(db.BusinessRatings.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyBusinessRating(int id)
        {
            return db.BusinessRatings.Any(x => x.id == id);
        }

    }
}