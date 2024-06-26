﻿using EvidenceKoni.Data;
using EvidenceKoni.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EvidenceKoni.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class StablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Změna controlleru pro přidání pageru
        //GET: Stables
        [AllowAnonymous]
        public IActionResult Index(int pg = 1)
        {
            List<Stable> stables = _context.Stable.OrderByDescending(o => o.Id).Include(s => s.Owners).Include(s => s.Horse).ToList();/////

            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = stables.Count;
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = stables.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //return View(stables);
            return View(data);
        }


        // GET: Stables/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stable == null)
            {
                return NotFound();
            }

            var stable = await _context.Stable
                .Include(s => s.Owners)
                .Include(c => c.Horse)/////
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stable == null)
            {
                return NotFound();
            }

            return View(stable);
        }

        // GET: Stables/Create/Změna na FullName(vytvořeno v Models=>Owner)
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "FullName");
            ViewData["HorseId"] = new SelectList(_context.Horse, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Paid,StabledFrom,StabledTo,Note,OwnerId,HorseId")] Stable stable)/////////
        {
            if (ModelState.IsValid)
            {
                var owner = await _context.Owner.FindAsync(stable.OwnerId);
                if (owner == null)
                {
                    // Majitel v databázi neexistuje:
                    ModelState.AddModelError("OwnerId", "K vytvoření ustájení je nutné mít přiřazeného majitele.");
                    return View(stable);
                }

                _context.Add(stable);
                await _context.SaveChangesAsync();

                TempData["message"] = "Ustájení bylo úspěšné přidáno";

                return RedirectToAction(nameof(Index));
            }

            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "FirstName", stable.OwnerId);
            ViewData["HorseId"] = new SelectList(_context.Horse, "Id", "Name", stable.HorseId);
            return View(stable);
        }


        // GET: Stables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stable == null)
            {
                return NotFound();
            }

            var stable = await _context.Stable.FindAsync(id);
            if (stable == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "FullName", stable.OwnerId);
            ViewData["HorseId"] = new SelectList(_context.Horse, "Id", "Name", stable.HorseId);  ////////
            return View(stable);
        }

        // POST: Stables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Paid,StabledFrom,StabledTo,Note,OwnerId,HorseId")] Stable stable)///////
        {
            if (id != stable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stable);
                    await _context.SaveChangesAsync();

                    TempData["message"] = "Data o ustájení byla úspěšsně upravena";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StableExists(stable.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "FullName", stable.OwnerId);
            return View(stable);
        }

        // GET: Stables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stable == null)
            {
                return NotFound();
            }

            var stable = await _context.Stable
                //.Include(s => s.Owners)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stable == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "FullName", stable.OwnerId);
            return View(stable);
        }

        // POST: Stables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stable == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Stable'  is null.");
            }
            var stable = await _context.Stable.FindAsync(id);
            if (stable != null)
            {
                _context.Stable.Remove(stable);
            }

            await _context.SaveChangesAsync();

            TempData["message"] = "Ustájení bylo úspěšně odstraněno";

            return RedirectToAction(nameof(Index));
        }

        private bool StableExists(int id)
        {
            return (_context.Stable?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
