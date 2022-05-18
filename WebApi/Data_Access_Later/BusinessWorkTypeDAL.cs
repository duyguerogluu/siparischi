using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Data_Access_Later
{
    public class BusinessWorkTypeDAL
    {
        Models.SiparischiEntities db = new Models.SiparischiEntities();

        public IEnumerable<Models.BusinessWorkType> GetAllBusinessWorkTypes()
        {
            return db.BusinessWorkTypes;
        }

        public Models.BusinessWorkType GetBusinessWorkTypesById(int id)
        {
            return db.BusinessWorkTypes.Find(id);
        }

        public Models.BusinessWorkType CreateBusinessWorkType(Models.BusinessWorkType businessWorkType)
        {
            db.BusinessWorkTypes.Add(businessWorkType);
            db.SaveChanges();
            return businessWorkType;
        }

        public Models.BusinessWorkType UpdateBusinessWorkType(int id, Models.BusinessWorkType businessWorkType)
        {
            db.Entry(businessWorkType).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return businessWorkType;
        }

        public void DeleteBusinessWorkType(int id)
        {
            db.BusinessWorkTypes.Remove(db.BusinessWorkTypes.Find(id));
            db.SaveChanges();
        }
    }
}