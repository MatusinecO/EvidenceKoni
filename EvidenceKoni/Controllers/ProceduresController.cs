using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidenceKoni.Data;
using EvidenceKoni.Models;
using Microsoft.AspNetCore.Authorization;

namespace EvidenceKoni.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class ProceduresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProceduresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var procedures = from o in _context.Procedure.Include(p => p.Horse).Include(p => p.Worker)
                             select o;
            procedures = procedures.OrderByDescending(p => p.DateOfProcedure); // Add this line
            if (!String.IsNullOrEmpty(SearchString?.Trim()))
            {
                procedures = procedures.Where(p => p.Horse.Name.ToLower().Contains(SearchString.Trim().ToLower()));
            }
            return View(await procedures.ToListAsync());
        }


        // GET: Procedures/Details/5

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procedure == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure
                .Include(p => p.Horse)
                .Include(p => p.Worker)
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
            ViewData["WorkerId"] = new SelectList(_context.Worker, "Id", "FullName");
            return View();
        }

        // POST: Procedures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Operation,DateOfProcedure,Price,Note,HorseId,WorkerId")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HorseId"] = new SelectList(_context.Horse, "Id", "Name", procedure.HorseId);
            ViewData["WorkerId"] = new SelectList(_context.Worker, "Id", "FullName", procedure.WorkerId);
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
            ViewData["WorkerId"] = new SelectList(_context.Worker, "Id", "FullName", procedure.WorkerId);
            return View(procedure);
        }

        // POST: Procedures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Operation,DateOfProcedure,Price,Note,HorseId,WorkerId")] Procedure procedure)
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
            ViewData["HorseId"] = new SelectList(_context.Horse, "Id", "Name", procedure.HorseId);
            ViewData["WorkerId"] = new SelectList(_context.Worker, "Id", "FullName", procedure.WorkerId);
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
