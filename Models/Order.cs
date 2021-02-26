using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Models
{
    [Table("Orders")]
    public class Order
    {
        [Column("OrderID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int OrderID { get; set; }

        [ForeignKey("Pharmcy")]
        [Display(Name = "Select Pharamcy")]
        public int PharmacyId { get; set; }

        [ForeignKey("Mediciene")]
        [Display(Name = "Selsct Mediciene")]
        public int MedicieneId { get; set; }

        //[ForeignKey("Person")]
        //[Display(Name = "Person Name")]
        //public int PersonId { get; set; }

        //[ForeignKey("Location")]
        //[Display(Name ="Locaton")]
        //public int LocatonID { get; set; }

        [Column("Price")]
        public double? Price { get; set; }

        [Column("Address")]
        [Display(Name = "Enter your Address")]
        public string Address { get; set; }
        
        [Column("Name")]
        [Display(Name = "Enter your Name")]
        public string Name { get; set; }

        [Column("Contact")]
        [Display(Name = "your Contact number")]
        public string ContactNumber { get; set; }


        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

        public Pharmcy Pharmcy { get; set; }

        public Medicine Mediciene { get; set; }

        //public Person Person { get; set; }

        //public Locaton Locaton { get; set; }
    }
}
