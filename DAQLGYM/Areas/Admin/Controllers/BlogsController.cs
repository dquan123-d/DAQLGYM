using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAQLGYM.Models;

namespace DAQLGYM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly QlgymContext _context;

        public BlogsController(QlgymContext context)
        {
            _context = context;
        }

        // GET: Admin/Blogs
        public async Task<IActionResult> Index()
        {
            var qlgymContext = _context.TblBlogs.Include(t => t.Account);
            return View(await qlgymContext.ToListAsync());
        }

        // GET: Admin/Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlog = await _context.TblBlogs
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (tblBlog == null)
            {
                return NotFound();
            }

            return View(tblBlog);
        }

        // GET: Admin/Blogs/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.TblAccounts, "AccountId", "AccountId");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,Title,Alias,Description,Detail,Image,SeoTitle,SeoDescription,SeoKeywords,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,AccountId,IsActive")] TblBlog tblBlog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.TblAccounts, "AccountId", "AccountId", tblBlog.AccountId);
            return View(tblBlog);
        }

        // GET: Admin/Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlog = await _context.TblBlogs.FindAsync(id);
            if (tblBlog == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.TblAccounts, "AccountId", "AccountId", tblBlog.AccountId);
            return View(tblBlog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogId,Title,Alias,Description,Detail,Image,SeoTitle,SeoDescription,SeoKeywords,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,AccountId,IsActive")] TblBlog tblBlog)
        {
            if (id != tblBlog.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBlogExists(tblBlog.BlogId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.TblAccounts, "AccountId", "AccountId", tblBlog.AccountId);
            return View(tblBlog);
        }

        // GET: Admin/Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBlog = await _context.TblBlogs
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (tblBlog == null)
            {
                return NotFound();
            }

            return View(tblBlog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBlog = await _context.TblBlogs.FindAsync(id);
            if (tblBlog != null)
            {
                _context.TblBlogs.Remove(tblBlog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBlogExists(int id)
        {
            return _context.TblBlogs.Any(e => e.BlogId == id);
        }
    }
}
