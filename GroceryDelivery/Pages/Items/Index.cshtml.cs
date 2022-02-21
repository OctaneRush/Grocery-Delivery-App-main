#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryDelivery.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryDelivery.Pages_Items
{
    public class IndexModel : PageModel
    {
        private readonly GroceryDelivery.Models.GroceryDbContext _context;

        public IndexModel(GroceryDelivery.Models.GroceryDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public IActionResult OnGet()
        {
            // Finds all items in the database.
            Item = _context.Items
                .Include(i => i.Order)
                .Include(i => i.Store).ToList();
                return Page();
        }
    }
}
