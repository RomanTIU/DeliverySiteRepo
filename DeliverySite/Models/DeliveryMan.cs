using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DeliverySite.Models
{
    public class DeliveryMan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nu ati introdus numele")]
        [DisplayName("Numele omului de livrare")]
        public string DeliveryManName { get; set; }

        [Required(ErrorMessage = "Nu ati introdus numarul de contact")]
        [DisplayName("Numarul de contact")]
        public int ContactNumberDeliveryMan { get; set; }

        [Required(ErrorMessage = "Nu ati introdus emailu")]
        [DisplayName("Adresa postala")]
        public string EmailDeliveryMan { get; set; }
        
        ICollection<Command> Commands { get; set; }


    }
}