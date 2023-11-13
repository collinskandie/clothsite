using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using clothStore.Models; // Adjust the namespace based on your project structure

namespace clothStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public IndexModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Cloth> ClothItems { get; set; }

        public void OnGet()
        {
            // Fetch ClothItems from the database
            ClothItems = _dbContext.Cloths.ToList();
        }
    }
}
