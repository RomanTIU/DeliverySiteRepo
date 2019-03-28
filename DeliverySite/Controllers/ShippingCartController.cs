using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliverySite.Models;

namespace DeliverySite.Controllers
{
    public class ShippingCartController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private string strCart = "Cart";
        // GET: ShippingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Session[strCart]==null)
            {
                List<Cart> listCart = new List<Cart>
                {
                    new Cart(_db.Products.Find(id), 1)
                };
                Session[strCart] = listCart;
            }
            else
            {
                List<Cart> listCart = (List<Cart>) Session[strCart];
                listCart.Add(new Cart(_db.Products.Find(id),1));
                Session[strCart] = listCart;
            }
            return View("Index");
        }
    }
}