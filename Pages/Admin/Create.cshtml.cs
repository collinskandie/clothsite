using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using clothStore;
using clothStore.Models;

namespace clothStore.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly clothStore.AppDbContext _context;

        public CreateModel(clothStore.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cloth Cloth { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cloths == null || Cloth == null)
            {
                return Page();
            }

            _context.Cloths.Add(Cloth);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
