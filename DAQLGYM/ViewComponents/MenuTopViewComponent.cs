using DAQLGYM.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAQLGYM.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly QlgymContext _context;

        public MenuTopViewComponent(QlgymContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TblMenus.ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
