using Microsoft.AspNetCore.Mvc;
using PortfolioCore.Context;
using PortfolioCore.Entities;

namespace PortfolioCore.Controllers
{
    public class ServiceController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult ServiceList()
        {
            var values = context.Services.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateService(Service services)
        {
            context.Services.Add(services);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = context.Services.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateService(Service services)
        {
            context.Services.Update(services);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        public IActionResult DeleteService(int id)
        {
            var value = context.Services.Find(id);
            context.Services.Remove(value);
            context.SaveChanges();

            return RedirectToAction("ServiceList");
        }
    }
}
