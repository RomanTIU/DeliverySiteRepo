using DeliverySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DeliverySite.Controllers
{
    public class SetSessionController : Controller
    {
        string strCart = "Cart";
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: SetSession
        public ActionResult SetVariable(int ProductId,int CartQuantity)
        {

            if (ProductId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                         

                List<Cart> listCart = (List<Cart>)Session[strCart];
                int check = IsExestCheck(ProductId);
                listCart[check].Quantity=CartQuantity;
                Session[strCart] = listCart;

            return this.Json(new { succes = true });
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
    }
    
}