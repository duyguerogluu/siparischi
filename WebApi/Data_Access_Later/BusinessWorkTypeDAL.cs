using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;
using System.Data.Entity;

namespace WebApi.Data_Access_Later
{
    public class BusinessWorkTypeDAL : BaseDAL
    {
        public IEnumerable<BusinessWorkType> GetAllBusinessWorkTypes()
        {
            return db.BusinessWorkTypes.ToList();
        }

        public BusinessWorkType GetBusinessWorkTypesById(int id)
        {
            return db.BusinessWorkTypes.Find(id);
        }

        public BusinessWorkType CreateBusinessWorkType(BusinessWorkType businessWorkType)
        {
            db.BusinessWorkTypes.Add(businessWorkType);
            db.SaveChanges();
            return businessWorkType;
        }

        public BusinessWorkType UpdateBusinessWorkType(int id, BusinessWorkType businessWorkType)
        {
            db.Entry(businessWorkType).State = EntityState.Modified;
            db.SaveChanges();
            return businessWorkType;
        }

        public void DeleteBusinessWorkType(int id)
        {
            db.BusinessWorkTypes.Remove(db.BusinessWorkTypes.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyBusinessWorkType(int id)
        {
            return db.BusinessWorkTypes.Any(x => x.id == id);
        }
    }
}