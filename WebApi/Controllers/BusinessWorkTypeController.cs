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
using System.Web.Http.Results;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;

namespace WebApi.Controllers
{
    public class BusinessWorkTypeController : ApiController
    {
        [Authorize]
        public HttpResponseMessage GetList()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from businessworktype", con);
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK,dataTable);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dataTable);
            }
        }

    }
}
