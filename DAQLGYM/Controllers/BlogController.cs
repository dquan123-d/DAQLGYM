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
            ViewData["bloglasted"] = _context.TblBlogs.OrderByDescending(i => i.CreatedDate).Take(5).ToList();
            ViewData["blognew"] = _context.TblBlogs.OrderByDescending(i => i.CreatedDate).FirstOrDefault();
            ViewData["categori"] = _context.TblClasses.Include(i => i.TblMemberPackages).ToList();
            var blog = _context.TblBlogs.Include(i=>i.TblBlogComments).ToList();
            return View(blog);
        }

        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblBlogs == null)
            {
                return NotFound();
            }
            var blog = await _context.TblBlogs.Include(i=>i.TblBlogComments).FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
    }
}