using Microsoft.AspNetCore.Mvc;

namespace DAQLGYM.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
