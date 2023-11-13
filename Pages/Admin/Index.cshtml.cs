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
    public class IndexModel : PageModel
    {
        private readonly clothStore.AppDbContext _context;

        public IndexModel(clothStore.AppDbContext context)
        {
            _context = context;
        }

        public IList<Cloth> Cloth { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cloths != null)
            {
                Cloth = await _context.Cloths.ToListAsync();
            }
        }
    }
}
