using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class BusinessTypeDAL : BaseDAL
    {
        public IEnumerable<BusinessType> GetAllBusinessTypes()
        {
            return db.BusinessTypes.ToList();
        }

        public IEnumerable<BusinessType> GetBusinessTypesById(int id)
        {
            return db.BusinessTypes.Where(x => x.id == id).ToList();
        }

        public BusinessType CreateBusinessType(BusinessType businessType)
        {
            db.BusinessTypes.Add(businessType);
            db.SaveChanges();
            return businessType;
        }

        public BusinessType UpdateBusinessType(BusinessType businessType)
        {
            db.Entry(businessType).State = EntityState.Modified;
            //db.SaveChanges();
            return businessType;
        }

        public void DeleteBusinessType(int id)
        {
            db.BusinessTypes.Remove(db.BusinessTypes.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyBusinessType(int id)
        {
            return db.BusinessTypes.Any(x => x.id == id);
        }

    }
} 