using DAQLGYM.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAQLGYM.Controllers
{
    public class TrainerController : Controller
    {
        private readonly QlgymContext _context;

        public TrainerController(QlgymContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var trainer = _context.TblTrainer
            return View();
        }
    }
}
