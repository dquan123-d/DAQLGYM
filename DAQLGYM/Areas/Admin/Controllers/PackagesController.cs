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
    public class PackagesController : Controller
    {
        private readonly QlgymContext _context;

        public PackagesController(QlgymContext context)
        {
            _context = context;
        }

        // GET: Admin/Packages
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblPackages.ToListAsync());
        }

        // GET: Admin/Packages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPackage = await _context.TblPackages
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (tblPackage == null)
            {
                return NotFound();
            }

            return View(tblPackage);
        }

        // GET: Admin/Packages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Packages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageId,PackageName,Duration,Price,Describe,ImagePackages")] TblPackage tblPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPackage);
        }

        // GET: Admin/Packages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPackage = await _context.TblPackages.FindAsync(id);
            if (tblPackage == null)
            {
                return NotFound();
            }
            return View(tblPackage);
        }

        // POST: Admin/Packages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageId,PackageName,Duration,Price,Describe,ImagePackages")] TblPackage tblPackage)
        {
            if (id != tblPackage.PackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPackageExists(tblPackage.PackageId))
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
            return View(tblPackage);
        }

        // GET: Admin/Packages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPackage = await _context.TblPackages
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (tblPackage == null)
            {
                return NotFound();
            }

            return View(tblPackage);
        }

        // POST: Admin/Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPackage = await _context.TblPackages.FindAsync(id);
            if (tblPackage != null)
            {
                _context.TblPackages.Remove(tblPackage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPackageExists(int id)
        {
            return _context.TblPackages.Any(e => e.PackageId == id);
        }
    }
}
