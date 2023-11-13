using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using clothStore;
using clothStore.Models;

namespace clothStore.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly clothStore.AppDbContext _context;

        public DetailsModel(clothStore.AppDbContext context)
        {
            _context = context;
        }

      public Cloth Cloth { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cloths == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloths.FirstOrDefaultAsync(m => m.Id == id);
            if (cloth == null)
            {
                return NotFound();
            }
            else 
            {
                Cloth = cloth;
            }
            return Page();
        }
    }
}
