using KindergartenCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace KindergartenCRUD.Pages.Kindergartens
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kindergarten Kindergarten { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Kindergarten.CreatedAt = DateTime.Now;
            Kindergarten.UpdatedAt = DateTime.Now;
            _context.Kindergartens.Add(Kindergarten);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}