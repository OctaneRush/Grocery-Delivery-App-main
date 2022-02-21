using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryDelivery.Models
{
    public class Store
    {
        [Key]
        public int StoreID {get; set;} // Primary Key
        public string? Name {get; set;}
        public string? Address {get; set;}
        [Display(Name = "Phone Number")]
        public string? PhoneNumber {get; set;}
        public List<Item>? Items {get; set;} // Navigation Property
    }
}