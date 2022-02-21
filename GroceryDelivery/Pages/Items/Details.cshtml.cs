#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceryDelivery.Models;

namespace GroceryDelivery.Pages_Items
{
    public class DetailsModel : PageModel
    {
        private readonly GroceryDelivery.Models.GroceryDbContext _context;

        public DetailsModel(GroceryDelivery.Models.GroceryDbContext context)
        {
            _context = context;
        }

        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Finds the selected item in the database. 
            Item = await _context.Items
                .Include(i => i.Order)
                .Include(i => i.Store).FirstOrDefaultAsync(m => m.ItemID == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
