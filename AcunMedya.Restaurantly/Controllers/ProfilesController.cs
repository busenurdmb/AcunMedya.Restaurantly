using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();

        // GET: Profiles
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var value = Db.Admins.Find(Session["id"]);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var value = Db.Admins.Find(p.AdminId);
            if (value.Password != p.Password)
            {
                ModelState.AddModelError(string.Empty, "Girdiğiniz şifre yanlış");
                return View(value);
            }
            if(p.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                var saveLocation = currentDirectory + "images\\";

                var fileName = Path.Combine(saveLocation, p.ImageFile.FileName);

                p.ImageFile.SaveAs(fileName);

                value.ImageUrl = "/images/" + p.ImageFile.FileName;
            }

            value.UserName = p.UserName;
            value.Name = p.Name;
            value.SurName = p.SurName;
            value.Password = p.Password;
            value.Email = p.Email;

            Db.SaveChanges();

           return RedirectToAction("Index", "Dahboard");
        }
    }
}