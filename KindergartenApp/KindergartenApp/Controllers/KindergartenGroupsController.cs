using KindergartenApp.Data;
using KindergartenApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KindergartenApp.Controllers
{
    public class KindergartenGroupsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public KindergartenGroupsController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KindergartenGroup group, List<IFormFile> PictureFiles)
        {
            if (ModelState.IsValid)
            {
                foreach (var pictureFile in PictureFiles)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + pictureFile.FileName;
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath + "/images", uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await pictureFile.CopyToAsync(fileStream);
                        }

                        var picture = new Picture
                        {
                            FilePath = "/images/" + uniqueFileName,
                            KindergartenGroup = group
                        };

                        _context.Pictures.Add(picture);
                    }
                }

                _context.KindergartenGroups.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var group = await _context.KindergartenGroups
                .Include(g => g.Pictures)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null) return NotFound();

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KindergartenGroup group)
        {
            if (id != group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(group);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.KindergartenGroups.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }
            return View(group);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var group = await _context.KindergartenGroups.FirstOrDefaultAsync(m => m.Id == id);
            if (group == null) return NotFound();

            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group = await _context.KindergartenGroups.FindAsync(id);
            if (group.PicturePath != null)
            {
                string filePath = _hostEnvironment.WebRootPath + group.PicturePath;
                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
            }
            _context.KindergartenGroups.Remove(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
