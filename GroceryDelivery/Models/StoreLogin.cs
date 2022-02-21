using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryDelivery.Models
{
    public class StoreLogin
    {
        [Required]
        [Display(Name = "Store Name")]
        public string? UserFirstName {get; set;}
        
    }
}