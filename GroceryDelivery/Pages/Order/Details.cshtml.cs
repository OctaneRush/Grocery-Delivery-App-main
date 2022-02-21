#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryDelivery.Models;

namespace GroceryDelivery.Pages_Order
{
    public class DetailsModel : PageModel
    {
        private readonly GroceryDelivery.Models.GroceryDbContext _context;

        public DetailsModel(GroceryDelivery.Models.GroceryDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Finds the selected order in the database.
            Order = await _context.Orders
                .Include(o => o.Customer).FirstOrDefaultAsync(m => m.OrderID == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
