using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GroceryDelivery.Models;

namespace GroceryDelivery.Models
{
    public class CustomerLogin
    {
        [Display(Name = "First Name")]
        public string? FirstName {get; set;}
        [Display(Name = "Last Name")]
        public string? LastName {get; set;}
    }
}