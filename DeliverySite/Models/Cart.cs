using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DeliverySite.Models
{
    public class Cart
    {
        public Product Product { get; set; }

        [DisplayName("Cantitatea")]
        public int Quantity { get; set; }

        public Cart(Product product, int quantity)
        {
            Product = product;

            Quantity = quantity;
        }
    }
}