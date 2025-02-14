using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class ProductController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Product
  

        public ActionResult ProductList()
        {

            var value = Db.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ProductCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product model)
        {
            Db.Products.Add(model);
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            var value = Db.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult ProductEdit(Product model)
        {
            var values = Db.Categories.Find(model.ProductId);
            //values.ProductName = model.ProductName;
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult ProductDelete(int id)
        {
            var value = Db.Categories.Find(id);
            Db.Categories.Remove(value);
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}