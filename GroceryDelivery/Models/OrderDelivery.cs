using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GroceryDelivery.Models
{
    public class OrderDelivery
    {
        [Key]
        public int DeliveryID {get; set;} // Primary Key
        public DateTime DateTime {get; set;}
        public int DelivererID {get; set;} // Foreign Key
        public DeliveryPerson? DeliveryPerson {get; set;} // Reference Object
        public int OrderID {get; set;} // Foreign Key
        public Order? Order {get; set;} // Reference Object
    }
}