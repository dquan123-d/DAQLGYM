using Microsoft.AspNetCore.Mvc;

namespace DAQLGYM.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
