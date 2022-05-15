using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    
    public class AdminController : ApiController
    {   
        //Gereksiz ogrenmek için
        public string Get()
        {
            try {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Admin", con);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            return JsonConvert.SerializeObject(dataTable);
                        }
                        else
                        {
                            return "Veri yok!";
                        }
                    }
                }
            }
            catch(Exception)
            {
                return "Error!";
            }
        }

        public string GetLogin(string username, string password)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from admin where " +
                            "(username='" + username + "') and " +
                            "(password='" + password + "')", con);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            return "1";
                        }
                        else
                        {
                            return "0";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "0";
            }

        }

    }
}
