using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class CategoryDAL : BaseDAL
    {
        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public IEnumerable<Category> GetCategoriesById(int id)
        {
            return db.Categories.Where(x => x.id == id).ToList();
        }

        public IEnumerable<Category> GetCategoriesByBusinessId(int businessId)
        {
            return db.Categories.Where(x => x.business_id == businessId).ToList();
        }

        public Category CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            //db.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyCategory(int id)
        {
            return db.Categories.Any(x => x.id == id);
        }

    }
}