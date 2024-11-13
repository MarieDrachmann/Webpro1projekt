using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplicationTest.Data;
using WebApplicationTest.Models;
using WebApplicationTest.ViewModel;

namespace WebApplicationTest.Controllers
{
    public class PicsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PicsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Pics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pics.ToListAsync());
        }

        // GET: Pics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pics = await _context.Pics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pics == null)
            {
                return NotFound();
            }

            return View(pics);
        }

        // GET: Pics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pics pics)
        {
            var user = await _userManager.GetUserAsync(User);
            if(user != null)
            {
                pics.foreign = user.Id;
            }

            if(pics.picFile != null && pics.picFile.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
                var checkExtension = Path.GetExtension(pics.picFile.FileName).ToLower();

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(pics.picFile.FileName);
                string extension = Path.GetExtension(pics.picFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Pics/", fileName);

                if (!allowedExtensions.Contains(checkExtension))
                {
                    ModelState.AddModelError("picFile", "Invalid file format.");
                    return RedirectToAction("UploadPictures", "Home");
                }

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await pics.picFile.CopyToAsync(fileStream);
                }
                pics.picPath = fileName;
            }

            ModelState.Remove("foreign");
   

            if (ModelState.IsValid)
            {
                _context.Add(pics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pics);
        }

        public IActionResult Show()
        {
            Display display = new Display();
            display.pics = _context.Pics.ToList();
            display.IUser = _context.Users.ToList();

            return View(display);
        }


        // GET: Pics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pics = await _context.Pics.FindAsync(id);
            if (pics == null)
            {
                return NotFound();
            }
            return View(pics);
        }

        // POST: Pics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,description,picPath,foreign")] Pics pics)
        {
            if (id != pics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PicsExists(pics.Id))
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
            return View(pics);
        }

        // GET: Pics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pics = await _context.Pics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pics == null)
            {
                return NotFound();
            }

            return View(pics);
        }

        // POST: Pics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pics = await _context.Pics.FindAsync(id);
            if (pics != null)
            {
                _context.Pics.Remove(pics);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PicsExists(int id)
        {
            return _context.Pics.Any(e => e.Id == id);
        }
    }
}
