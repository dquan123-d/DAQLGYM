using Microsoft.AspNetCore.Mvc;

namespace DAQLGYM.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
