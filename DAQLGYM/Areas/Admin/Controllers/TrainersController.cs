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
    public class TrainersController : Controller
    {
        private readonly QlgymContext _context;

        public TrainersController(QlgymContext context)
        {
            _context = context;
        }

        // GET: Admin/Trainers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTrainers.ToListAsync());
        }

        // GET: Admin/Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTrainer = await _context.TblTrainers
                .FirstOrDefaultAsync(m => m.TrainerId == id);
            if (tblTrainer == null)
            {
                return NotFound();
            }

            return View(tblTrainer);
        }

        // GET: Admin/Trainers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainerId,FullName,Experience,ContactInfo,ProfileImage")] TblTrainer tblTrainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTrainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTrainer);
        }

        // GET: Admin/Trainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTrainer = await _context.TblTrainers.FindAsync(id);
            if (tblTrainer == null)
            {
                return NotFound();
            }
            return View(tblTrainer);
        }

        // POST: Admin/Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainerId,FullName,Experience,ContactInfo,ProfileImage")] TblTrainer tblTrainer)
        {
            if (id != tblTrainer.TrainerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTrainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTrainerExists(tblTrainer.TrainerId))
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
            return View(tblTrainer);
        }

        // GET: Admin/Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTrainer = await _context.TblTrainers
                .FirstOrDefaultAsync(m => m.TrainerId == id);
            if (tblTrainer == null)
            {
                return NotFound();
            }

            return View(tblTrainer);
        }

        // POST: Admin/Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTrainer = await _context.TblTrainers.FindAsync(id);
            if (tblTrainer != null)
            {
                _context.TblTrainers.Remove(tblTrainer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTrainerExists(int id)
        {
            return _context.TblTrainers.Any(e => e.TrainerId == id);
        }
    }
}
