﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Models
{
    [Table("Persons")]
    public class Person
    {

        [Column("PersonID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PersonID { get; set; }


        [Column("Name")]
        [Required]
        [Display(Name = "Name")]
        [StringLength(100)]
        public string Name { get; set; }

        //[Column("Locaton")]
        //[Display(Name = "Locaton")]
        //[StringLength(100)]
        //public string Locaton { get; set; }

        [ForeignKey("AspnetUsers")]
        public string UserId { get; set; }
        
        [ForeignKey("Locaton")]
        public int LocatonId { get; set; }


        //public User User { get; set; }

        public Locaton Locaton { get; set; }
    }
}
