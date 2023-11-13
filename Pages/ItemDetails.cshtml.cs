using clothStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace clothStore.Pages
{
    public class ItemDetailsModel : PageModel
    {
        private readonly clothStore.AppDbContext _context;
        public ItemDetailsModel(clothStore.AppDbContext context)
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
