 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliverySite.Models
{
    public enum Sphere { Pizza = 0 , Burgher = 1 , Sushi = 2 }
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nu ati introdus denumirea producatorului")]
        [DisplayName("Numele producatorului")]
        public string ManufacturerName{ get; set; }

        [Required(ErrorMessage = "Nu ati introdus adresa")]
        [DisplayName("Adresa producatorului")]
        public string AdressManufacturer { get; set; }

        [Required(ErrorMessage = "Nu ati introdus numarul de contact")]
        [DisplayName("Numarul de contact al producatorului")]
        public int ContactNumberManufacurer { get; set; }

        [Required(ErrorMessage = "Nu ati introdus emailu")]
        [DisplayName("Adresa postala a producatorului")]
        public string EmailManufacturer { get; set; }

        [Required(ErrorMessage = "Nu ati introdus domeniul")]
        [DisplayName("Domeniul de activitate")]
        public Sphere ShereManufacturer { get; set; }

        [DisplayName("Loggo")]
        public string ImagePathLoggo { get; set; }

        
        public ICollection<Product> Product { get; set; }
        public ICollection<Command> Command { get; set; }
    }
}