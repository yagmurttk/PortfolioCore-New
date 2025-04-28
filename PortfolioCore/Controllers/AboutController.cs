using Microsoft.AspNetCore.Mvc;
using PortfolioCore.Context;
using PortfolioCore.Entities;

namespace PortfolioCore.Controllers
{
    public class AboutController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult AboutList()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                about.ImageURL = fileName;
                context.Abouts.Add(about);
                context.SaveChanges();
            }

            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                about.ImageURL = fileName;
            }
            else
            {
                about.ImageURL = context.Abouts.Find(about.AboutId).ImageURL;
            }

            var updatedAbout = context.Abouts.Find(about.AboutId);
            if (updatedAbout != null)
            {
                updatedAbout.Description = about.Description;
                updatedAbout.JobTitle = about.JobTitle;
                updatedAbout.Email = about.Email;
                updatedAbout.Phone = about.Phone;
                updatedAbout.City = about.City;
                updatedAbout.SubDescription = about.SubDescription;
                updatedAbout.ImageURL = about.ImageURL;
                context.SaveChanges();
            }

            return RedirectToAction("AboutList");
        }

        public IActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

    }
}