using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RoleController : Controller
    {
        Blood_bankEntities db = new Blood_bankEntities();
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayRole()
        {
            List<Role> list = db.Roles.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            List<int> list = db.users.Select(x => x.Id).ToList();
            ViewBag.id = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(Role ro)
        {
            db.Roles.Add(ro);
            db.SaveChanges();
            return RedirectToAction("DisplayRole");
        }

        [HttpGet]
        public ActionResult UpdateRole(int id)
        {
            List<int> list = db.users.Select(x => x.Id).ToList();
            ViewBag.id = new SelectList(list);
            Role r = db.Roles.Where(x => x.Id == id).SingleOrDefault();
            return View(r);
        }

        [HttpPost]
        public ActionResult UpdateRole(int id, Role ro)
        {
            Role r = db.Roles.Where(x => x.Id == id).SingleOrDefault();
            r.UserId = ro.UserId;
            r.Role1 = ro.Role1;
            db.SaveChanges();
            return RedirectToAction("DisplayRole");
        }

        [HttpGet]
        public ActionResult DetailRole(int id)
        {
            Role ro = db.Roles.Where(x => x.Id == id).SingleOrDefault();
            return View(ro);
        }

        [HttpGet]
        public ActionResult DeleteRole(int id)
        {
            Role ro = db.Roles.Where(x => x.Id == id).SingleOrDefault();
            return View(ro);
        }

        [HttpPost]
        public ActionResult DeleteRole(int id, Role ro)
        {
            Role r = db.Roles.Where(x => x.Id == id).SingleOrDefault();
            db.Roles.Remove(r);
            db.SaveChanges();
            return RedirectToAction("DisplayRole");
        }
    }
}