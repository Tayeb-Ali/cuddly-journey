using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Models
{
    [Table("aspnetusers")]
    public class User
    {
        public User()
        {
            Persons = new List<Person>();
        }

        [Column("UserID")]
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        public int UserID { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        
        public string PhoneNumber { get; set; }

        public List<Person> Persons { get; set; }
    }
}
