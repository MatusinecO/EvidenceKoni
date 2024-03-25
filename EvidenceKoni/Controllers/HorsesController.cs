﻿using System;
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
    public class HorsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Změna controlleru pro přidání pageru
        //GET: Horses
        public IActionResult Index(int pg = 1)
        {
            List<Horse> horses = _context.Horse.Include(s => s.Owners).ToList();

            const int pageSize = 6;
            if (pg < 1)
                pg = 1;

            int recsCount = horses.Count;
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = horses.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //return View(horses);
            return View(data);
        }

        /*
        // GET: Horses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Horse.Include(h => h.Owners);
            return View(await applicationDbContext.ToListAsync());
        }
        */

        // GET: Horses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Horse == null)
            {
                return NotFound();
            }

            var horse = await _context.Horse
                .Include(h => h.Owners)
                .Include(p => p.Procedures)               // --> přidal sem procedury
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horse == null)
            {
                return NotFound();
            }

            return View(horse);
        }
        
       
        // GET: Horses/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Set<Owner>(), "Id", "FullName");
            return View();
        }

        // POST: Horses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDate,Burn,Chip,LifeNumber,CardNumber,Breed,Sex,Color,Description,Note,OwnerId")] Horse horse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<Owner>(), "Id", "FullName", horse.OwnerId);
            return View(horse);
        }

        // GET: Horses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Horse == null)
            {
                return NotFound();
            }

            var horse = await _context.Horse.FindAsync(id);
            if (horse == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<Owner>(), "Id", "FullName", horse.OwnerId);
            return View(horse);
        }

        // POST: Horses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDate,Burn,Chip,LifeNumber,CardNumber,Breed,Sex,Color,Description,Note,OwnerId")] Horse horse)
        {
            if (id != horse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorseExists(horse.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Set<Owner>(), "Id", "FullName", horse.OwnerId);
            return View(horse);
        }

        // GET: Horses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Horse == null)
            {
                return NotFound();
            }

            var horse = await _context.Horse
                .Include(h => h.Owners)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horse == null)
            {
                return NotFound();
            }

            return View(horse);
        }

        // POST: Horses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Horse == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Horse'  is null.");
            }
            var horse = await _context.Horse.FindAsync(id);
            if (horse != null)
            {
                _context.Horse.Remove(horse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorseExists(int id)
        {
          return (_context.Horse?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
