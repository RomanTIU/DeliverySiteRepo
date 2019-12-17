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
    public class CartsController : Controller
    {
        private string strCart = "Cart";
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carts
        //public ActionResult Index()
        //{
        //    return View(db.Carts.ToList());
        //}

        // GET: Carts/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cart);
        //}

        // GET: Carts/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }           
            if (Session[strCart] == null)
            {
                List<Cart> listCart = new List<Cart>
                {
                    new Cart(db.Products.Find(id), 1)
                };
                Session[strCart] = listCart;
            }
            else
            {                
                List<Cart> listCart = (List<Cart>)Session[strCart];
                int check = IsExestCheck(id);
                if (check == -1)
                {
                    listCart.Add(new Cart(db.Products.Find(id), 1));
                }
                else
                {
                    listCart[check].Quantity++;
                }
                Session[strCart] = listCart;
            }            
            return View();
        }

        //POST: Carts/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cart cart)
        {


            if (ModelState.IsValid)
            {

                List<Cart> listCart = (List<Cart>)Session[strCart];

                return RedirectToAction("");
            }

            return View();
        }




        // GET: Carts/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cart);
        //}

        //// POST: Carts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Quantity,TotalPrice")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cart).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(cart);
        //}

        //// GET: Carts/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cart);
        //}

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private int IsExestCheck(int? id)
        {
            List<Cart> listCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < listCart.Count; i++)
            {
                if (listCart[i].Product.Id == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public ActionResult DeleteCart(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int check = IsExestCheck(id);
            List<Cart> listCart = (List<Cart>)Session[strCart];
            listCart.RemoveAt(check);
            return View("Create");
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
