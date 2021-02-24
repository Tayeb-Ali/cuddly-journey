using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Models
{
    [Table("Medicines")]
    public class Medicine
    {
        [Column("MedicineID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int MedicineID { get; set; }


        [Column("BrandName")]
        [Required]
        [Display(Name = "Brand Name")]
        [StringLength(100)]
        public string BrandName { get; set; }

        [Column("ScientificName")]
        [Required]
        [StringLength(100)]
        [Display(Name = "Scientific Name")]
        public string ScientificName { get; set; }

        [Column("Type")]
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Column("Price")]
        [Required]
        public Double Price { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }


    }
}
