using Microsoft.AspNetCore.Mvc.RazorPages;
using KindergartenCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace KindergartenCRUD.Pages.Kindergartens
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Kindergarten> Kindergartens { get; set; }

        public async Task OnGetAsync()
        {
            Kindergartens = await _context.Kindergartens.ToListAsync();
        }
    }
}
