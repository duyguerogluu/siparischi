using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class BusinessHourDAL : BaseDAL
    {
        public IEnumerable<BusinessHour> GetAllBusinessHours()
        {
            return db.BusinessHours.ToList();
        }

        public IEnumerable<BusinessHour> GetBusinessHoursById(int id)
        {
            return db.BusinessHours.Where(x => x.id == id).ToList();
        }

        public BusinessHour CreateBusinessHour(BusinessHour businessHour)
        {
            db.BusinessHours.Add(businessHour);
            db.SaveChanges();
            return businessHour;
        }

        public BusinessHour UpdateBusinessHour(BusinessHour businessHour)
        {
            db.Entry(businessHour).State = EntityState.Modified;
            //db.SaveChanges();
            return businessHour;
        }

        public void DeleteBusinessHour(int id)
        {
            db.BusinessHours.Remove(db.BusinessHours.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyBusinessHour(int id)
        {
            return db.BusinessHours.Any(x => x.id == id);
        }
    }
}