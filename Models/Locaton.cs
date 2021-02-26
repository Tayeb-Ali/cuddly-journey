using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Models
{
    [Table("Locatons")]
    public class Locaton
    {
 
        [Column("LocatonID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int LocatonID { get; set; }

        [Column("Country")]
        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Column("State")]
        [Required]
        [StringLength(50)]
        public string State { get; set; }


        [Column("NumberOfStreet")]
        [Required]
        [Display(Name = "Number Of Street")]
        [StringLength(20)]
        public string NumberOfStreet { get; set; }
        
        [Column("HomeNumber")]
        [Required]
        [Display(Name = "Home Number")]
        [StringLength(20)]
        public string HomeNumber { get; set; }

        public List<Order> Orders { get; set; }
        public List<Person> Persons { get; set; }
    }
}
