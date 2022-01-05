using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        Blood_bankEntities db = new Blood_bankEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayUser()
        {
            List<user> list = db.users.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(user us)
        {
            db.users.Add(us);
            db.SaveChanges();
            return RedirectToAction("DisplayUser");
        }


        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            user u = db.users.Where(x => x.Id == id).SingleOrDefault();
            return View(u);
        }

        [HttpPost]
        public ActionResult UpdateUser(int id, user us)
        {
            user u = db.users.Where(x => x.Id == id).SingleOrDefault();
            u.Name = us.Name;
            u.Contact = us.Contact;
            u.Password = us.Password;
            db.SaveChanges();
            return RedirectToAction("DisplayUser");
        }

        [HttpGet]
        public ActionResult DetailUser(int id)
        {
            user us = db.users.Where(x => x.Id == id).SingleOrDefault();
            return View(us);
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            user us = db.users.Where(x => x.Id == id).SingleOrDefault();
            return View(us);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id, user us)
        {
            user u = db.users.Where(x => x.Id == id).SingleOrDefault();
            db.users.Remove(u);
            db.SaveChanges();
            return RedirectToAction("DisplayUser");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user us, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.users.Where(x => x.Name == us.Name && x.Password == us.Password).FirstOrDefault();

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(us.Name, false);
                    Session["uname"] = us.Name.ToString();
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return Redirect("/Home/Index");
                    }
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["uname"] = null;
            return RedirectToAction("Login");
        }
    }
}