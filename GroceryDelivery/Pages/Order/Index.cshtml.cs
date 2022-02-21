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
    public class IndexModel : PageModel
    {
        private readonly GroceryDelivery.Models.GroceryDbContext _context;

        public IndexModel(GroceryDelivery.Models.GroceryDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            // Finds all orders in the database.
            Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
        }
    }
}
