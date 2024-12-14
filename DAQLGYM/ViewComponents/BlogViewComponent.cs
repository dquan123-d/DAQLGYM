using Microsoft.AspNetCore.Mvc;

namespace DAQLGYM.ViewComponents
{
    public class BlogViewComponent : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
