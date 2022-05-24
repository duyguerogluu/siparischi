using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Data_Access_Later;

namespace WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        CategoryDAL categoryDAL = new CategoryDAL();

        [Authorize]
        public HttpResponseMessage Get()//https://localhost:44378/api/category?apiKey=1
        {
            var category = categoryDAL.GetAllCategories();
            if (category != null)
                return Request.CreateResponse(HttpStatusCode.OK, category);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage Get(int id)//https://localhost:44378/api/category/get/1?apiKey=1
        {
            var category = categoryDAL.GetCategoriesById(id);
            if (category != null)
                return Request.CreateResponse(HttpStatusCode.OK, categoryDAL.GetCategoriesById(id));
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage GetBusinessCategory(int businessId)//https://localhost:44378/api/category/getbusinesscategory/1?apiKey=1
        {
            var category = categoryDAL.GetCategoriesByBusinessId(businessId);
            if (category != null)
                return Request.CreateResponse(HttpStatusCode.OK, categoryDAL.GetCategoriesByBusinessId(businessId));
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage Post(Category category)//https://localhost:44378/api/category?apiKey=1 ---> Content: {"category_name":"Pizzalar", "image_name":"pizza.jpeg", "status":"Aktif", "creation_date":"1", "business_id":"1"}
        {
            //validation kurallarını sağlamıyorsa
            if (ModelState.IsValid)
            {
                var createdCategory = categoryDAL.CreateCategory(category);
                return Request.CreateResponse(HttpStatusCode.Created, createdCategory);
            }
            //OK
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Authorize]
        public HttpResponseMessage Put(int id, Category category)//https://localhost:44378/api/category/put/3?apiKey=1 ---> Content: {"category_name":"Pizzalar", "image_name":"pizza.jpeg", "status":"Aktif", "creation_date":"1", "business_id":"1"}
        {
            //id ye ait kayıt yoksa
            if (!categoryDAL.IsThereAnyCategory(id))
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
                return Request.CreateResponse(HttpStatusCode.OK, categoryDAL.UpdateCategory(category));
            }
        }

        [Authorize]
        public HttpResponseMessage Delete(int id)//https://localhost:44378/api/category/delete/3?apiKey=1
        {
            //id ye ait kayıt yoksa
            if (categoryDAL.IsThereAnyCategory(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //OK
            else
            {
                categoryDAL.DeleteCategory(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

    }
}
