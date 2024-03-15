using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidenceKoni.Data;
using EvidenceKoni.Models;

namespace EvidenceKoni.Controllers
{
    public class ProceduresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProceduresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Procedures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Procedure.Include(p => p.Horse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Procedures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procedure == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure
                .Include(p => p.Horse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // GET: Procedures/Create
        public IActionResult Create()
        {
            ViewData["HorseId"] = new SelectList(_context.Horse, "Id", "Name");
            return View();
        }

        // POST: Procedures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Profession,Operation,DateOfProcedure,Price,Note,HorseId")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HorseId"] = new SelectList(_context.Horse, "Id", "Id", procedure.HorseId);
            return View(procedure);
        }

        // GET: Procedures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procedure == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }
            ViewData["HorseId"] = new SelectList(_context.Horse, "Id", "Name", procedure.HorseId);
            return View(procedure);
        }

        // POST: Procedures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Profession,Operation,DateOfProcedure,Price,Note,HorseId")] Procedure procedure)
        {
            if (id != procedure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedureExists(procedure.Id))
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
            ViewData["HorseId"] = new SelectList(_context.Horse, "Id", "FullName", procedure.HorseId);
            return View(procedure);
        }

        // GET: Procedures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procedure == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure
                .Include(p => p.Horse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // POST: Procedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procedure == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Procedure'  is null.");
            }
            var procedure = await _context.Procedure.FindAsync(id);
            if (procedure != null)
            {
                _context.Procedure.Remove(procedure);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedureExists(int id)
        {
          return (_context.Procedure?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
