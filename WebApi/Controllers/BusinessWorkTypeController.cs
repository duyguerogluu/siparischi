using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BusinessWorkTypeController : ApiController
    {
        public string GetList()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from businessworktype", con);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            string jsonString = string.Empty;
                            jsonString = JsonConvert.SerializeObject(dataTable);
                            return jsonString;
                        }
                        else
                        {
                            return "Henüz veri yok!";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "Bağlantı sağlanamadı";
            }
        }

    }
}
