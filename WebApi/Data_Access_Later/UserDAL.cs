using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class UserDAL : BaseDAL
    {
        public User GetUserByApiKey(string apiKey)
        {
            return db.Users.FirstOrDefault(x => x.user_key.ToString() == apiKey);
        }
    }
}