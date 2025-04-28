using Microsoft.AspNetCore.Mvc;

namespace PortfolioCore.Controllers
{
    public class ErrorPageController : Controller
    {

        public ActionResult Page404()
        {
            return View();
        }
    }
}
