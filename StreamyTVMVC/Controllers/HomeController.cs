using StreamyTVMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamyTVMVC.Controllers
{
    public class HomeController : Controller
    {
        private TelevisionDBEntities db = new TelevisionDBEntities();

        public ActionResult _Navbar()
        {
            return View();
        }
        public ActionResult _HomeCarousel()
        {
            var shows = db.Shows;
            return View(shows.ToList());
        }
        public ActionResult _NetworkButtonsRow()
        {
            var networks = db.Networks;
            return View(networks.ToList());
        }
        public ActionResult Index()
        {
            ViewBag.ShowList = db.Shows.ToList();
            ViewBag.NetworkList = db.Networks.ToList();
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
    }
}