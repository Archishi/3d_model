using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(18, ErrorMessage = "Не длиннее 18 символов")]
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Date_registration { get; set; }
        public List <Order> Orders { get; set; } = new List<Order> ();
    }
}
