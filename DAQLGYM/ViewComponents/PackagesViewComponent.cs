using DAQLGYM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAQLGYM.ViewComponents
{
    public class PackagesViewComponent : ViewComponent
    {
        private readonly QlgymContext _context;
        public PackagesViewComponent(QlgymContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TblPackages.ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
