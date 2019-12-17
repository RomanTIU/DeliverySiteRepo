using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliverySite.Models
{
    public  class Singleton
    {
        private static  Singleton Connect = new Singleton();
        string role;
        private Singleton() {

            role = "Admin";  
        }
        public static Singleton getinstance()
        {
            return Connect;
        }

    }
}