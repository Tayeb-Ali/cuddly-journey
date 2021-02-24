using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Models
{
    [Table("Pharmcys")]
    public class Pharmcy
    {
        public Pharmcy()
        {
            Stocks = new List<Stock>();
        }

        [Column("PharmcyID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PharmcyID { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Column("Location")]
        [Required]
        [StringLength(100)]
        public string Location { get; set; }


        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

        public List<Stock> Stocks { get; set; }


    }


}
