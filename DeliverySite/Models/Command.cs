using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliverySite.Models
{
    public class Command : IEnumerable
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Cumparatorul")]
        public string ClientId { get; set; }

        [DisplayName("Numele producatorului")]
        public int ManufacturerId { get; set; }

        [DisplayName("Denumirea produsului")]
        public int ProductId { get; set; }

        [DisplayName("Statutul produsului")]
        public int StatusId { get; set; }

        [DisplayName("Suma spre achitare")]
        public int SumCommand { get; set; }



        public ApplicationUser Client { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Product Product { get; set; }
        public Status Status { get; set; }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}