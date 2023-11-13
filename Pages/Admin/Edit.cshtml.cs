using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clothStore;
using clothStore.Models;

namespace clothStore.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly clothStore.AppDbContext _context;

        public EditModel(clothStore.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cloth Cloth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cloths == null)
            {
                return NotFound();
            }

            var cloth =  await _context.Cloths.FirstOrDefaultAsync(m => m.Id == id);
            if (cloth == null)
            {
                return NotFound();
            }
            Cloth = cloth;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cloth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothExists(Cloth.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClothExists(int id)
        {
          return (_context.Cloths?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
