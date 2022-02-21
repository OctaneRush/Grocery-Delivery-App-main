using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryDelivery.Models
{
    public class Order
    {
        [Key]
        public int OrderID {get; set;} // Primary Key
        [Display(Name = "Price Paid")]
        public double PricePaid {get; set;}
        public int CustomerID {get; set;} // Foreign Key
        public Customer? Customer {get; set;} // Reference Object
        public List<Item>? Items {get; set;} // Navigation Property
        public OrderDelivery? OrderDelivery {get; set;} // Reference Object
    }
}