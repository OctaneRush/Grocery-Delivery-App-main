#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryDelivery.Models;

namespace GroceryDelivery.Pages_Order
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
            // Creates a dropdown of Customers to select for the order.
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Adds the order to the database.
            await _context.AddOrderAsync(Order);

            return RedirectToPage("./Index");
        }
    }
}
