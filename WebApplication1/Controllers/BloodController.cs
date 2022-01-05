using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BloodController : Controller
    {
        Blood_bankEntities db = new Blood_bankEntities();
        // GET: Blood
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayBlood()
        {
            List<Blood> list = db.Bloods.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateBlood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlood(Blood blo)
        {
            db.Bloods.Add(blo);
            db.SaveChanges();
            return RedirectToAction("DisplayBlood");
        }

        [HttpGet]
        public ActionResult UpdateBlood(int id)
        {
            Blood bl = db.Bloods.Where(x => x.Id == id).SingleOrDefault();
            return View(bl);
        }

        [HttpPost]
        public ActionResult UpdateBlood(int id, Blood blo)
        {
            Blood bl = db.Bloods.Where(x => x.Id == id).SingleOrDefault();
            bl.Blood_group = blo.Blood_group;
            bl.Blood_quantity = blo.Blood_quantity;
            bl.Blood_fee = blo.Blood_fee;
            db.SaveChanges();
            return RedirectToAction("DisplayBlood");
        }

        [HttpGet]
        public ActionResult DetailBlood(int id)
        {
            Blood blo = db.Bloods.Where(x => x.Id == id).SingleOrDefault();
            return View(blo);
        }

        [HttpGet]
        public ActionResult DeleteBlood(int id)
        {
            Blood blo = db.Bloods.Where(x => x.Id == id).SingleOrDefault();
            return View(blo);
        }

        [HttpPost]
        public ActionResult DeleteBlood(int id, Blood blo)
        {
            Blood b = db.Bloods.Where(x => x.Id == id).SingleOrDefault();
            db.Bloods.Remove(b);
            db.SaveChanges();
            return RedirectToAction("DisplayBlood");
        }
    }
}