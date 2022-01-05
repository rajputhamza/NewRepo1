using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SellController : Controller
    {
        Blood_bankEntities db = new Blood_bankEntities();
        // GET: Sell
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplaySell()
        {
            List<Sell> list = db.Sells.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateSell()
        {
            List<string> list = db.Bloods.Select(x => x.Blood_group).ToList();
            ViewBag.BloodGroup = new SelectList(list);
            List<string> list1 = db.Bloods.Select(x => x.Blood_fee).ToList();
            ViewBag.Bloodcharges = new SelectList(list1);
            return View();
        }

        [HttpPost]
        public ActionResult CreateSell(Sell sel)
        {
            db.Sells.Add(sel);
            db.SaveChanges();
            return RedirectToAction("DisplaySell");
        }

        [HttpGet]
        public ActionResult UpdateSell(int id)
        {
            Sell se = db.Sells.Where(x => x.Id == id).SingleOrDefault();
            List<string> list = db.Bloods.Select(x => x.Blood_group).ToList();
            ViewBag.BloodGroup = new SelectList(list);
            List<string> list1 = db.Bloods.Select(x => x.Blood_fee).ToList();
            ViewBag.Bloodcharges = new SelectList(list1);
            return View(se);
        }

        [HttpPost]
        public ActionResult UpdateSell(int id, Sell sel)
        {
            Sell se = db.Sells.Where(x => x.Id == id).SingleOrDefault();
            se.Sell_name = sel.Sell_name;
            se.Sell_contact = sel.Sell_contact;
            se.Sell_group = sel.Sell_group;
            se.Sell_count = sel.Sell_count;
            se.Sell_fee = sel.Sell_fee;
            se.Sell_date = sel.Sell_date;
            db.SaveChanges();
            return RedirectToAction("DisplaySell");
        }

        [HttpGet]
        public ActionResult DetailSell(int id)
        {
            Sell sel = db.Sells.Where(x => x.Id == id).SingleOrDefault();
            return View(sel);
        }

        [HttpGet]
        public ActionResult DeleteSell(int id)
        {
            Sell sel = db.Sells.Where(x => x.Id == id).SingleOrDefault();
            return View(sel);
        }

        [HttpPost]
        public ActionResult DeleteSell(int id, Sell sel)
        {
            Sell se = db.Sells.Where(x => x.Id == id).SingleOrDefault();
            db.Sells.Remove(se);
            db.SaveChanges();
            return RedirectToAction("DisplaySell");
        }
    }
}