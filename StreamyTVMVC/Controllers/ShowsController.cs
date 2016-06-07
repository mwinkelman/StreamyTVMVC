using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StreamyTVMVC.Models;

namespace StreamyTVMVC.Controllers
{
    public class ShowsController : Controller
    {
        private TelevisionDBEntities db = new TelevisionDBEntities();

        // GET: Shows
        public ActionResult _NetworkNavbar(int id)
        {
            Network network = db.Networks.Find(id); 
            return View(network);
           
        }
        public ActionResult _NetworkPageContent(int id)
        {
            ViewBag.Network = db.Networks.Find(id);
            var shows = from show in db.Shows
                        where show.NetworkID == id
                        select show;

            return View(shows.ToList());
        }
        public ActionResult Index(int id)
        {
            Network network = db.Networks.Find(id);
            return View(network);       
        }
        public ActionResult Search(string searchString)
        {

            var shows = from show in db.Shows
                        select show;
            if(!String.IsNullOrEmpty(searchString))
            {
                shows = shows.Where(s => s.ShowName.Contains(searchString));
            }

            return View(shows);
        }
        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "NetworkName");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowID,ShowName,NetworkID,Seasons,Genre,ShowImage,ShowDescription,CarouselImage")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "NetworkName", show.NetworkID);
            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "NetworkName", show.NetworkID);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowID,ShowName,NetworkID,Seasons,Genre,ShowImage,ShowDescription,CarouselImage")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "NetworkName", show.NetworkID);
            return View(show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.Shows.Find(id);
            db.Shows.Remove(show);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
