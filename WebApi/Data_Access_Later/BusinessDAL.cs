using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class BusinessDAL : BaseDAL
    {
        public Business GetBusinessByApiKey(string apiKey)
        {
            return db.Businesses.FirstOrDefault(x => x.business_key.ToString() == apiKey);
        }
    }
}