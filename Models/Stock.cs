using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Models
{
    [Table("Stocks")]
    public class Stock
    {
        public Stock()
        {
            Pharmcy = new Pharmcy();
            Mediciene = new Medicine();
        }
        [Column("StockID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int StockID { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("Pharmcy")]
        public int PharmacyId { get; set; }

        [ForeignKey("Mediciene")]
        public int MedicieneId { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }


        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }


        public Pharmcy Pharmcy { get; set; }

        public Medicine Mediciene { get; set; }
    }
}
