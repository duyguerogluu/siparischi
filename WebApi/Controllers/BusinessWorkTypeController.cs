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
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebApi.Data_Access_Later;
using WebApi.Models;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace WebApi.Controllers
{
    public class BusinessWorkTypeController : ApiController
    {
        BusinessWorkTypeDAL businessWorkTypeDAL = new BusinessWorkTypeDAL();

        [ResponseType(typeof(IEnumerable<BusinessWorkType>))]
        [Authorize]
        public IHttpActionResult Get()//https://localhost:44378/api/BusinessWorkType?apiKey=1
        {
            var businessworktype = businessWorkTypeDAL.GetAllBusinessWorkTypes();
            if (businessworktype != null)
                return Ok(businessworktype);
            else
                return NotFound();
        }

        [ResponseType(typeof(IEnumerable<BusinessWorkType>))]
        [Authorize]
        public IHttpActionResult Get(int id)//https://localhost:44378/api/BusinessWorkType/get/1?apiKey=1
        {
            var businessworktype = businessWorkTypeDAL.GetBusinessWorkTypesById(id);
            if (businessworktype != null)
                return Ok(businessworktype);
            else
                return NotFound();
        }
        [ResponseType(typeof(IEnumerable<BusinessWorkType>))]
        [Authorize]
        public HttpResponseMessage Post(BusinessWorkType businessWorkType)//https://localhost:44378/api/BusinessWorkType?apiKey=1 ---> Content: {"work_type":"Hergün"}
        {
            //validation kurallarını sağlamıyorsa
            if (ModelState.IsValid)
            {
                var createdBusinessWorkType = businessWorkTypeDAL.CreateBusinessWorkType(businessWorkType);
                return Request.CreateResponse(HttpStatusCode.Created, createdBusinessWorkType);
            }
            //OK
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        [ResponseType(typeof(IEnumerable<BusinessWorkType>))]
        [Authorize]
        public HttpResponseMessage Put(int id, BusinessWorkType businessWorkType)
        {
            //id ye ait kayıt yoksa
            if (!businessWorkTypeDAL.IsThereAnyBusinessWorkType(id))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //validation kurallarını sağlamıyorsa
            else if (ModelState.IsValid == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            //OK
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK,businessWorkTypeDAL.UpdateBusinessWorkType(id,businessWorkType));
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            //id ye ait kayıt yoksa
            if (businessWorkTypeDAL.IsThereAnyBusinessWorkType(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //OK
            else
            {
                businessWorkTypeDAL.DeleteBusinessWorkType(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

    }
}
