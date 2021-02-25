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
        public int PharmacyId { get; set; }

        [ForeignKey("Mediciene")]
        public int MedicieneId { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        [ForeignKey("Location")]
        public int Location { get; set; }

        [Column("Price")]
        public double Price { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

        public Pharmcy Pharmcy { get; set; }

        public Medicine Mediciene { get; set; }

        public Person Person { get; set; }

        public Locaton Locaton { get; set; }
    }
}
