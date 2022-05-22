using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Data_Access_Later
{
    public class BaseDAL
    {
        protected Models.SiparischiEntities db;
        public BaseDAL()
        {
            db = new Models.SiparischiEntities();
        }
    }
}