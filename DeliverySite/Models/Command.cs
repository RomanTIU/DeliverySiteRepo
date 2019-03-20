using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliverySite.Models
{
    public class Command
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Numele cumparatorului")]
        public int ClientID { get; set; }

        [DisplayName("Numele producatorului")]
        public int ManufacturerID { get; set; }

        [DisplayName("Denumirea produsului")]
        public int ProductID { get; set; }

        [DisplayName("Statutul produsului")]
        public int StatusID { get; set; }
        [DisplayName("Suma spre achitare")]
        public int SumCommand { get; set; }



        
        public  Manufacturer Manufacturer { get; set; }
        public  Product Product { get; set; }
        public  Status Status { get; set; }
       

        
        ICollection<DeliveryMan> DeliveryMen { get; set; }
    }
}