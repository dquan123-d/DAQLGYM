using DAQLGYM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAQLGYM.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly QlgymContext _context;

        public BlogViewComponent(QlgymContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TblBlogs.Include(i=>i.TblBlogComments).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
