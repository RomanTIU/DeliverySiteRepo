using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace DeliverySite.Models
{

    public enum Colors { Red=0,Yellow=1,Green=2}
    public class Status
    {
                
        [Key]
        public int Id { get; set; }
        [DisplayName("Statutul comenzei")]
        public Colors ColorStatus  { get; set; }
      
        public ICollection<Command> Commanda { get; set; }
    }
}