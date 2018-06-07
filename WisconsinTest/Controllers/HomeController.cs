using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WisconsinTest.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace WisconsinTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            Session["LogedUserID"] = "";
            return View();
        }


        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        WiscounsinTestDatabaseEntities db = new WiscounsinTestDatabaseEntities();

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

                        return RedirectToAction("Index", "Psychologist");
                    }
                }
            }
            ViewBag.Error = "Logowanie nie powiodło się.";
            return View(u);
        }

        public ActionResult PsychologistRegistration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PsychologistRegistration(Users user, Psychologists psychologist)
        {
            Users existsUser = CheckUserExists(user.Login);


            if (existsUser == null)
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.Psychologists.Add(psychologist);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                    //return Redirect(Url.Action("Index", "Psychologist"));
                }
            }
            else
                ModelState.AddModelError("", "Użytkownik o podanym loginie już istnieje");

            return View();
        }

        public Users CheckUserExists(string userName)
        {
            return db.Users.Where(x => x.Login == userName).FirstOrDefault();
        }



        }
    }
