﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saidality.Models
{
    [Table("Pharmcys")]
    public class Pharmcy
    {
   
        [Column("PharmcyID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PharmcyID { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("LocatonID")]
        [Display(Name = "Select Locaton")]
        public int LocatonID { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

        public List<Stock> Stocks { get; set; }
        public List<Medicine> Medicines { get; set; }
        public Locaton Locaton { get; set; }


    }


}
