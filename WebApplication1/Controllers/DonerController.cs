using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DonerController : Controller
    {
        Blood_bankEntities db = new Blood_bankEntities();
        // GET: Doner
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayDoner()
        {
            List<Doner> list = db.Doners.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateDoner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDoner(Doner don)
        {
            db.Doners.Add(don);
            db.SaveChanges();
            return RedirectToAction("DisplayDoner");
        }

        [HttpGet]
        public ActionResult UpdateDoner(int id)
        {
            Doner dr = db.Doners.Where(x => x.Id == id).SingleOrDefault();
            return View(dr);
        }

        [HttpPost]
        public ActionResult UpdateDoner(int id, Doner don)
        {
            Doner dr = db.Doners.Where(x => x.Id == id).SingleOrDefault();
            dr.Doner_name = don.Doner_name;
            dr.Doner_contact = don.Doner_contact;
            dr.Doner_address = don.Doner_address;
            db.SaveChanges();
            return RedirectToAction("DisplayDoner");
        }

        [HttpGet]
        public ActionResult DetailDoner(int id)
        {
            Doner don = db.Doners.Where(x => x.Id == id).SingleOrDefault();
            return View(don);
        }

        [HttpGet]
        public ActionResult DeleteDoner(int id)
        {
            Doner don = db.Doners.Where(x => x.Id == id).SingleOrDefault();
            return View(don);
        }

        [HttpPost]
        public ActionResult DeleteDoner(int id, Doner don)
        {
            Doner d = db.Doners.Where(x => x.Id == id).SingleOrDefault();
            db.Doners.Remove(d);
            db.SaveChanges();
            return RedirectToAction("DisplayDoner");
        }
    }
}