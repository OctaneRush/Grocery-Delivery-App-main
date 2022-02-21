using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryDelivery.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID {get; set;}  // Primary Key
        [Display(Name = "First Name")]
        public string? FirstName {get; set;}
        [Display(Name = "Last Name")]
        public string? LastName {get; set;}
        public string? Address {get; set;}
        [Display(Name = "Phone Number")]
        public string? PhoneNumber {get; set;}
        public string? Email {get; set;}
        [Display(Name = "Credit Card")]
        public int CreditCard {get; set;}
        [Display(Name = "Name")]
        public string FullName 
        {
            get {return FirstName + " " + LastName;}
        }
        public List<OrderDelivery>? OrderDeliveries {get; set;} // Navigation Property
    }
}