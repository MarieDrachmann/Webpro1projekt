﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebProProjekt.Data;
using WebProProjekt.Data.Migrations;
using WebProProjekt.Models;
using WebProProjekt.ViewModel;


namespace WebProProjekt.Controllers
{
    [Authorize]
    public class OurPicUploadsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public OurPicUploadsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }

		public async Task<IActionResult> Index()
		{
			return View(await _context.OurPicUpload.ToListAsync());
		}
		public IActionResult ShowOurPicUploads() //Displays the picture when called
        {
            Display display = new Display(); //Makes new object for the picture
            display.pics = _context.OurPicUpload.ToList(); //Goes into the viewmodel Display and gets the pics list from the database and puts them into the list to display
            display.IUser = _context.Users.ToList(); //The same as before, but here its the data about the user who put up the picture

            return View(display); //Returns a view with the pictures
        }

		// GET: OurPicUploads/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourPicUpload = await _context.OurPicUpload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourPicUpload == null)
            {
                return NotFound();
            }

            return View(ourPicUpload);
        }

        // GET: OurPicUploads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OurPicUploads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OurPicUploads ourPicUpload)
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            ourPicUpload.ProfileId = user.Id;

			ModelState.Remove("ProfileId");
			if (ourPicUpload.PicFile != null && ModelState.IsValid) //ModelState.IsValid tjekker om kravende til modellen er opfyldt
			{
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" }; 
                var checkExtension = Path.GetExtension(ourPicUpload.PicFile.FileName).ToLower();
                var picName = Path.GetFileNameWithoutExtension(ourPicUpload.PicFile.FileName);
                var extension = Path.GetExtension(ourPicUpload.PicFile.FileName);
                picName = picName + DateTime.Now.ToString("yymmssfff") + extension;

                //cross site scripting
                StringBuilder titleSB = new StringBuilder();
                titleSB.Append(HttpUtility.HtmlEncode(ourPicUpload.PicTitle));
                StringBuilder desSB = new StringBuilder();
                desSB.Append(HttpUtility.HtmlEncode(ourPicUpload.PicDescription));

                titleSB.Replace("&#230;", "æ");
                titleSB.Replace("&#248;", "ø");
                titleSB.Replace("&#229;", "å");

                desSB.Replace("&#230;", "æ");
                desSB.Replace("&#248;", "ø"); //Den burde vise ø men det gør den ikke?
                desSB.Replace("&#229;", "å");

                ourPicUpload.PicTitle = titleSB.ToString();
                ourPicUpload.PicDescription = desSB.ToString();


                var uploadPath = Path.Combine(_hostEnvironment.WebRootPath, "Pics");
				if (!Directory.Exists(uploadPath))
				{
					Directory.CreateDirectory(uploadPath);
				}

				var path = Path.Combine(_hostEnvironment.WebRootPath + "/Pics/", picName);

                if (!allowedExtensions.Contains(checkExtension))
                {
                    ModelState.AddModelError("PicFile", "Invalid file format.");
                    return RedirectToAction("OurPicUpload");
                }

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await ourPicUpload.PicFile.CopyToAsync(fileStream);
                }

                ourPicUpload.PicPath = picName;

				ModelState.AddModelError("PicFile", "Please upload a file");


				_context.Add(ourPicUpload);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ShowOurPicUploads));
                
			}

            

            return View(ourPicUpload);

        }

        // GET: OurPicUploads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourPicUpload = await _context.OurPicUpload.FindAsync(id);
            if (ourPicUpload == null)
            {
                return NotFound();
            }
            return View(ourPicUpload);
        }

        // POST: OurPicUploads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,OurPicUploads ourPicUpload)
        {
            //cross site scripting
            StringBuilder titleSB = new StringBuilder();
            titleSB.Append(HttpUtility.HtmlEncode(ourPicUpload.PicTitle));
            StringBuilder desSB = new StringBuilder();
            desSB.Append(HttpUtility.HtmlEncode(ourPicUpload.PicDescription));

            titleSB.Replace("&#230;", "æ");
            titleSB.Replace("&#248;", "ø");
            titleSB.Replace("&#229;", "å");

            desSB.Replace("&#230;", "æ");
            desSB.Replace("&#248;", "ø"); //Den burde vise ø men det gør den ikke?
            desSB.Replace("&#229;", "å");

            ourPicUpload.PicTitle = titleSB.ToString();
            ourPicUpload.PicDescription = desSB.ToString();
            if (id != ourPicUpload.Id)
            {
                return NotFound();
            }

            ModelState.Remove("ProfileId");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ourPicUpload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurPicUploadExists(ourPicUpload.Id))
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
            return View(ourPicUpload);
        }

        // GET: OurPicUploads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourPicUpload = await _context.OurPicUpload
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourPicUpload == null)
            {
                return NotFound();
            }

            return View(ourPicUpload);
        }

        // POST: OurPicUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ourPicUpload = await _context.OurPicUpload.FindAsync(id);
            if (ourPicUpload != null)
            {
                _context.OurPicUpload.Remove(ourPicUpload);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurPicUploadExists(int id)
        {
            return _context.OurPicUpload.Any(e => e.Id == id);
        }
    }
}
