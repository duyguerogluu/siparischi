using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class AdminDAL : BaseDAL
    {
        public Admin GetAdminByApiKey(string apiKey)
        {
            return db.Admins.FirstOrDefault(x => x.admin_key.ToString() == apiKey);
        }
    }
}