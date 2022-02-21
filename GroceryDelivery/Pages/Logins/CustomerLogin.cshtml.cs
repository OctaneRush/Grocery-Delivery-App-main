#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryDelivery.Models;

namespace GroceryDelivery.Pages.Logins
{
    public class CustomerLoginModel : PageModel
    {
        private readonly GroceryDbContext _context;
        private readonly ILogger<CustomerLoginModel> _logger;

        [BindProperty]
        public Customer Customer {get; set;}
        public CustomerLoginModel(GroceryDbContext context, ILogger<CustomerLoginModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            // Creates a dropdown for Customer selection.
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName");
        }
    }
}