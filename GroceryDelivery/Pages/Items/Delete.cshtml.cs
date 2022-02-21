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
    public class DeleteModel : PageModel
    {
        private readonly GroceryDelivery.Models.GroceryDbContext _context;

        public DeleteModel(GroceryDelivery.Models.GroceryDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Accesses the selected item in the database.
            Item = await _context.Items.FindAsync(id);

            if (Item != null)
            {
                // Deletes item from the database.
                _context.Items.Remove(Item);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
