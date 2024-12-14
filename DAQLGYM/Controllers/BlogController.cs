using DAQLGYM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAQLGYM.Controllers
{
    public class BlogController : Controller
    {
        private readonly QlgymContext _context;
        public BlogController(QlgymContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/blog/{alias}-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblBlogs == null)
            {
                return NotFound();
            }
            var blog = await _context.TblBlogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _context.TblBlogComments.Where(i => i.BlogId == id).ToList();
            return View(blog);
        }
    }
}