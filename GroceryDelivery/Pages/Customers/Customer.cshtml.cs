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

namespace GroceryDelivery.Pages.Customers
{
    public class CustomerModel : PageModel
    {
        private readonly GroceryDbContext _context;
        private readonly ILogger<CustomerModel> _logger;

        public List<Customer> Customers {get; set;}

        public CustomerModel(GroceryDbContext context, ILogger<CustomerModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            // Takes all current Customers in database and puts them in a list.
            Customers = _context.Customers.ToList();
        }
    }
}
