using Microsoft.AspNetCore.Mvc;

namespace PortfolioCore.ViewComponents
{
    public class _DefaultScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
