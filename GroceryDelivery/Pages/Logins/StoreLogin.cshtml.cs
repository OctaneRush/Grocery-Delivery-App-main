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
    public class StoreLoginModel : PageModel
    {
        private readonly GroceryDbContext _context;
        private readonly ILogger<StoreLoginModel> _logger;

        [BindProperty]
        public Store Store {get; set;}
        public StoreLoginModel(GroceryDbContext context, ILogger<StoreLoginModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            // Creates a dropdown for Store selection.
            ViewData["StoreID"] = new SelectList(_context.Stores, "StoreID", "Name");
        }
    }
}