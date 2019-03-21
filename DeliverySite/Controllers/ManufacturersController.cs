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
    public class ManufacturersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Manufacturers
        public ActionResult Index()
        {
            return View(db.Manufacturers.ToList());
        }

        // GET: Manufacturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Create
        public ActionResult Create(int? id)
        {
            var manufacturerCreate = new Manufacturer();
            if (id != null)
            {
                var a = db.Manufacturers.Find(id);
                if (a != null)
                {
                    manufacturerCreate.ImagePathLoggo = a.ImagePathLoggo;
                }

                try
                {
                    var img = db.Manufacturers.Find(manufacturerCreate.Id);
                    if (img != null) manufacturerCreate.ImagePathLoggo = "~/Content/Manufacturers" + img.ImagePathLoggo;
                }
                catch
                {
                    return View("Error");
                }
            }
            return View();
        }

        // POST: Manufacturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ManufacturerName,AdressManufacturer,ContactNumberManufacurer,EmailManufacturer,ShereManufacturer")] Manufacturer manufacturer, HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    if (imageUpload.ContentType == "image/jpg" || imageUpload.ContentType == "image/png "
                                                               || imageUpload.ContentType == "image/jpeg" ||
                                                               imageUpload.ContentType == "image/gif")
                    {
                        imageUpload.SaveAs(Server.MapPath("/") + "/Content/Manufacturers/" + imageUpload.FileName);
                        manufacturer.ImagePathLoggo = imageUpload.FileName;
                    }
                    else
                        return View();
                }
                else return View();

                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: Manufacturers/Edit/5
        public ActionResult Edit(int? id)
        {

            var manufacturerEdit = new Manufacturer();
            if (id != null)
            {
                var a = db.Manufacturers.Find(id);
                if (a != null)
                {
                    manufacturerEdit.ImagePathLoggo = a.ImagePathLoggo;
                }

                try
                {
                    var img = db.Manufacturers.Find(manufacturerEdit.Id);
                    if (img != null) manufacturerEdit.ImagePathLoggo = "~/Content/Manufacturers" + img.ImagePathLoggo;
                }
                catch
                {
                    return View("Error");
                }
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            return View(manufacturer);
        }
        // POST: Manufacturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ManufacturerName,AdressManufacturer,ContactNumberManufacurer,EmailManufacturer,ShereManufacturer,ImagePathLoggo")] Manufacturer manufacturer,HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    if (imageUpload.ContentType == "image/jpg" ||
                        imageUpload.ContentType == "image/png" || 
                        imageUpload.ContentType == "image/jpeg"||
                        imageUpload.ContentType == "image/gif")
                    {
                        imageUpload.SaveAs(Server.MapPath("/") + "/Content/Manufacturers/" + imageUpload.FileName);
                        manufacturer.ImagePathLoggo = imageUpload.FileName;
                    }
                    else
                        return View();
                }
                else return View();




                db.Entry(manufacturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            db.Manufacturers.Remove(manufacturer);
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
