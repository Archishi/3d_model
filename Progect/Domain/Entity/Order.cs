using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int Final_sum { get; set; }
        [Required]
        public string Status_orders { get; set; }
        public DateTime Date_order { get; set; }
        public DateTime Date_end { get; set; }
    }
}
