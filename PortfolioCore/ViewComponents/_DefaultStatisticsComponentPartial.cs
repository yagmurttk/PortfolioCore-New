using Microsoft.AspNetCore.Mvc;
using PortfolioCore.Context;

namespace PortfolioCore.ViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        PortfolioContext context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Testimonials.Count();
            ViewBag.v2 = context.Portfolios.Count();
            ViewBag.v3 = context.Skills.Count();

            Random random = new Random();

            int randomStats = random.Next(10, 21);

            ViewBag.v4 = randomStats;

            return View();
        }
    }
}