#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryDelivery.Models;

namespace GroceryDelivery.Pages_Items
{
    public class CreateModel : PageModel
    {
        private readonly GroceryDelivery.Models.GroceryDbContext _context;

        public CreateModel(GroceryDelivery.Models.GroceryDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        // Creates two new dropdown lists on the create item form.
        ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderID");
        ViewData["StoreID"] = new SelectList(_context.Stores, "StoreID", "StoreID");
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Adds the new item to the database.
            await _context.AddItemAsync(Item);

            return RedirectToPage("./Index");
        }
    }
}
