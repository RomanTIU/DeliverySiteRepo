using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliverySite.Models;

namespace DeliverySite.Controllers
{
    public class DeliveryMenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeliveryMen
        public ActionResult Index()
        {
            return View(db.DeliveryMen.ToList());
        }

        // GET: DeliveryMen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryMan deliveryMan = db.DeliveryMen.Find(id);
            if (deliveryMan == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMan);
        }

        // GET: DeliveryMen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryMen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeliveryManName,ContactNumberDeliveryMan,EmailDeliveryMan,CommandId")] DeliveryMan deliveryMan)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryMen.Add(deliveryMan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryMan);
        }

        // GET: DeliveryMen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryMan deliveryMan = db.DeliveryMen.Find(id);
            if (deliveryMan == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMan);
        }

        // POST: DeliveryMen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeliveryManName,ContactNumberDeliveryMan,EmailDeliveryMan,CommandId")] DeliveryMan deliveryMan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryMan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryMan);
        }

        // GET: DeliveryMen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryMan deliveryMan = db.DeliveryMen.Find(id);
            if (deliveryMan == null)
            {
                return HttpNotFound();
            }
            return View(deliveryMan);
        }

        // POST: DeliveryMen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryMan deliveryMan = db.DeliveryMen.Find(id);
            db.DeliveryMen.Remove(deliveryMan);
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
