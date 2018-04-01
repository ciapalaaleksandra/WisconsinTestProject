using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WisconsinTest.Models;
using System.Data.Entity;

namespace WisconsinTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users u)
        {
            
            using (WiscounsinTestDatabaseEntities db = new WiscounsinTestDatabaseEntities())
            {
                
                if (u.Login != null && u.Passowrd != null)
                {
                    var v = db.Users.Where(a => a.Login == u.Login && a.Passowrd == u.Passowrd).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.UserId.ToString();
                        Session["LogedUserLogin"] = v.Login.ToString();
                        
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            ViewBag.Error = "Logowanie nie powiodlo sie.";
            return View(u);

        }


    }
}