using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class CategoryController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Category
        public ActionResult Index()
        {
            var value = Db.Categories.ToList();
            return View(value);
        }
        public ActionResult CategoryList()
        {

            var value = Db.Categories.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryCreate(Category model)
        {
            Db.Categories.Add(model);
            Db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var value= Db.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category model)
        {
            var values = Db.Categories.Find(model.CategoryId);
            values.CategoryName=model.CategoryName;
            Db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult CategoryDelete(int id)
        {
            var value= Db.Categories.Find(id);
            Db.Categories.Remove(value);
            Db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

    }
}