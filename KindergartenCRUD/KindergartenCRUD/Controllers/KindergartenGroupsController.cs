using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KindergartenCRUD.Data;
using KindergartenCRUD.Models;

namespace KindergartenCRUD.Controllers
{
    public class KindergartenGroupsController : Controller
    {
        private readonly AppDbContext _context;

        public KindergartenGroupsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.KindergartenGroups.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergartenGroup kindergartenGroup)
        {
            if (ModelState.IsValid)
            {
                kindergartenGroup.CreatedAt = DateTime.Now;
                kindergartenGroup.UpdatedAt = DateTime.Now;
                _context.Add(kindergartenGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kindergartenGroup);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindergartenGroup = await _context.KindergartenGroups.FindAsync(id);
            if (kindergartenGroup == null)
            {
                return NotFound();
            }
            return View(kindergartenGroup);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, KindergartenGroup kindergartenGroup)
        {
            if (id != kindergartenGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kindergartenGroup.UpdatedAt = DateTime.Now;
                    _context.Update(kindergartenGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindergartenGroupExists(kindergartenGroup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kindergartenGroup);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindergartenGroup = await _context.KindergartenGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kindergartenGroup == null)
            {
                return NotFound();
            }

            return View(kindergartenGroup);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kindergartenGroup = await _context.KindergartenGroups.FindAsync(id);
            _context.KindergartenGroups.Remove(kindergartenGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindergartenGroupExists(int id)
        {
            return _context.KindergartenGroups.Any(e => e.Id == id);
        }
    }
}
