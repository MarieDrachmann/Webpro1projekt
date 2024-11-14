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
            var user = await _userManager.GetUserAsync(User); //The one who is logged in, get them
            if(user != null) //Checks if there is a user
            {
                pics.foreign = user.Id; //Makes a foreign key so you can find the piture that fits the profile
            }

            if(pics.picFile != null && pics.picFile.Length > 0) //If there is a picture and the filename is longer than 0
            {
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" }; //The picture needs to have one of these in its name
                var checkExtension = Path.GetExtension(pics.picFile.FileName).ToLower(); //Changes the filename to lowercase

                string wwwRootPath = _hostEnvironment.WebRootPath; //The path to the folder in which the picture is, because the pictures path is saved into the database
                string fileName = Path.GetFileNameWithoutExtension(pics.picFile.FileName); //Gets the path to the pic without the .jpeg and such
                string extension = Path.GetExtension(pics.picFile.FileName); //Gets the whole name of the path
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension; //Adds a timestamp to the picture path, because the timestamp is saved onto the path when uploading picture
                string path = Path.Combine(wwwRootPath + "/Pics/", fileName); //puts the path together to be able to find the picture

                if (!allowedExtensions.Contains(checkExtension)) //If the fileformat is wrong, you cant upload picture
                {
                    ModelState.AddModelError("picFile", "Invalid file format.");
                    return RedirectToAction("UploadPictures", "Home");
                }

                using (var fileStream = new FileStream(path, FileMode.Create)) //Gets the pic using the path made earlier
                {
                    await pics.picFile.CopyToAsync(fileStream); //Waits to get the picture before continuing
                }
                pics.picPath = fileName; //Sets the picture given to the methods path to the name created earlier
            }

            ModelState.Remove("foreign"); //Removes the foreign key from the object? Its use if for connecting and displaying the correct values when getting the picture with the correct profile
   

            if (ModelState.IsValid) //If the object made fits the model, its true
            {
                _context.Add(pics); //Adds the pic into the database
                await _context.SaveChangesAsync(); //Waits for the data being saved into the database
                return RedirectToAction(nameof(Index)); //When uploaded picture, you are shown to the indexpage of the pics views
            }
            return View(pics); //Returns the view with the pic given in parameters
        }

        /*public IActionResult Show() //Displays the picture when called
        {
            Display display = new Display(); //Makes new object for the picture
            display.pics = _context.Pics.ToList(); //Goes into the viewmodel Display and gets the pics list from the database and puts them into the list to display
            display.IUser = _context.Users.ToList(); //The same as before, but here its the data about the user who put up the picture

            return View(display); //Returns a view with the pictures
        }*/


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
