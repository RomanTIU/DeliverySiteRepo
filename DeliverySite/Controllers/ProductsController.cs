using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DeliverySite.Models;

namespace DeliverySite.Controllers 
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        
        
        
              

        // GET: Products
        public ActionResult Index()
        {
            var products = _db.Products.Include(p => p.Manufacturer);
            return View(products.ToList());
            
            
        }

        public ActionResult Observer()
        {
            return View();
        }

        // GET: Products
        public ActionResult Pizza()
        {
            var products = _db.Products.Include(p => p.Manufacturer);
            return View(products.ToList());
        }

        // GET: Products
        public ActionResult Burghers()
        {
            var products = _db.Products.Include(p => p.Manufacturer);
            return View(products.ToList());
        }

        // GET: Products
        public ActionResult Shushi()
        {
            var products = _db.Products.Include(p => p.Manufacturer);
            return View(products.ToList());
        }
        // GET: Products/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int? id)
        {
            var productCreate = new Product();
            if (id != null)
            {
                var a = _db.Products.Find(id);
                if (a != null)
                {
                    productCreate.ImagePath = a.ImagePath;
                }

                try
                {
                    var img = _db.Products.Find(productCreate.Id);
                    if (img != null) productCreate.ImagePath = "~/Content/Image" + img.ImagePath;
                }
                catch
                {
                    return View("Error");
                }
            }

            ViewBag.ManufacturerID = new SelectList(_db.Manufacturers, "ID", "ManufacturerName");

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize (Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,TimeToReady,Price,Title,ManufacturerID")] Product product, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    if (uploadImage.ContentType == "image/jpg" ||
                        uploadImage.ContentType == "image/png" || 
                        uploadImage.ContentType == "image/jpeg"||
                        uploadImage.ContentType == "image/gif")
                    {
                        uploadImage.SaveAs(Server.MapPath("/") + "/Content/Image/" + uploadImage.FileName);
                        product.ImagePath = uploadImage.FileName;
                    }
                    else
                        return View();
                }
                else return View();

                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerID = new SelectList(_db.Manufacturers, "ID", "ManufacturerName", product.ManufacturerId);
            return View(product);
        }
        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {


            var productEdit = new Product();
            if (id != null)
            {
                var a = _db.Products.Find(id);
                if (a != null)
                {
                    productEdit.ImagePath = a.ImagePath;
                }

                try
                {
                    var img = _db.Products.Find(productEdit.Id);
                    if (img != null) productEdit.ImagePath = "~/Content/Image" + img.ImagePath;
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
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerID = new SelectList(_db.Manufacturers, "ID", "ManufacturerName", product.ManufacturerId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,TimeToReady,Price,Title,ImagePath,ManufacturerID")] Product product,HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (uploadImage != null)
                    {
                        if (uploadImage.ContentType == "image/jpg" || 
                            uploadImage.ContentType == "image/png" || 
                            uploadImage.ContentType == "image/jpeg"||
                            uploadImage.ContentType == "image/gif")
                        {
                            uploadImage.SaveAs(Server.MapPath("/") + "/Content/Image/" + uploadImage.FileName);
                            product.ImagePath = uploadImage.FileName;
                        }
                        else
                            return View();
                    }
                    else return View();
                }

                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Observer");
            }
            ViewBag.ManufacturerID = new SelectList(_db.Manufacturers, "ID", "ManufacturerName", product.ManufacturerId);
            return View(product);
        }
        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
