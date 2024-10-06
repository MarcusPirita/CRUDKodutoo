using KindergartenCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace KindergartenCRUD.Pages.Kindergartens
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var kindergartenToUpdate = await _context.Kindergartens.FindAsync(Kindergarten.Id);
            if (kindergartenToUpdate == null)
            {
                return NotFound();
            }
            
            _context.Entry(kindergartenToUpdate).CurrentValues.SetValues(Kindergarten);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool KindergartenExists(int id)
        {
            return _context.Kindergartens.Any(e => e.Id == id);
        }
    }
}
