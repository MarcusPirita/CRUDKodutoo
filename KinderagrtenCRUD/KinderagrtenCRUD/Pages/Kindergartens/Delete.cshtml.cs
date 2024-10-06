using KindergartenCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KindergartenCRUD.Pages.Kindergartens
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kindergarten Kindergarten { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Kindergarten = await _context.Kindergartens.FindAsync(id);

            if (Kindergarten == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Kindergarten = await _context.Kindergartens.FindAsync(id);

            if (Kindergarten != null)
            {
                _context.Kindergartens.Remove(Kindergarten);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
