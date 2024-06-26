﻿using EvidenceKoni.Data;
using EvidenceKoni.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvidenceKoni.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class WorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Změna controlleru pro přidání pageru
        //GET: Workers
        [AllowAnonymous]
        public IActionResult Index(int pg = 1)
        {
            List<Worker> workers = _context.Worker.OrderByDescending(o => o.Id).ToList();

            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = workers.Count;
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = workers.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //return View(workers);
            return View(data);
        }

        // GET: Workers/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Worker == null)
            {
                return NotFound();
            }

            var worker = await _context.Worker
                .Include(s => s.Procedures) //Přidáno
                .ThenInclude(h => h.Horse) // Přidáno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Profession,Adress,City,Phone,Email")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worker);
                await _context.SaveChangesAsync();

                TempData["message"] = "Nový pracovník byl úspěšně vytvořen";

                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Worker == null)
            {
                return NotFound();
            }

            var worker = await _context.Worker.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Profession,Adress,City,Phone,Email")] Worker worker)
        {
            if (id != worker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worker);
                    await _context.SaveChangesAsync();

                    TempData["message"] = "Data o pracovníkovi byla úspěšně upravena";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.Id))
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
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Worker == null)
            {
                return NotFound();
            }

            var worker = await _context.Worker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Worker == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Worker'  is null.");
            }
            var worker = await _context.Worker.FindAsync(id);
            if (worker != null)
            {
                _context.Worker.Remove(worker);
            }

            await _context.SaveChangesAsync();

            TempData["message"] = "Pracovník byl úspěšně odstraněn";

            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
            return (_context.Worker?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
