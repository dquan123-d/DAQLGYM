using DAQLGYM.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAQLGYM.Controllers
{
    public class ContactController : Controller
    {

        private readonly QlgymContext _context;

        public ContactController(QlgymContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TblContact contact)
        {
            contact.ModifiedDate = DateTime.Now;
            contact.CreatedDate = DateTime.Now;
            contact.CreatedBy = contact.Name;
            contact.ModifiedBy = contact.Name;
            _context.TblContacts.Add(contact);
            _context.SaveChanges();
            return View(contact);
        }
    }
}
