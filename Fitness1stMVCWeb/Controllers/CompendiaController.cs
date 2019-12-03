using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fitness1stMVCWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace Fitness1stMVCWeb.Controllers
{
    public class CompendiaController : Controller
    {
        private readonly CompendiumDbContext _context;

        public CompendiaController(CompendiumDbContext context)
        {
            _context = context;
        }

        // GET: Compendia
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compendium.ToListAsync());
        }

        // GET: Compendia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compendium = await _context.Compendium
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compendium == null)
            {
                return NotFound();
            }

            return View(compendium);
        }

        // GET: Compendia/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compendia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Category,Codes,METs,Description")] Compendium compendium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compendium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compendium);
        }

        // GET: Compendia/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compendium = await _context.Compendium.FindAsync(id);
            if (compendium == null)
            {
                return NotFound();
            }
            return View(compendium);
        }

        // POST: Compendia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Category,Codes,METs,Description")] Compendium compendium)
        {
            if (id != compendium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compendium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompendiumExists(compendium.Id))
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
            return View(compendium);
        }

        // GET: Compendia/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compendium = await _context.Compendium
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compendium == null)
            {
                return NotFound();
            }

            return View(compendium);
        }

        // POST: Compendia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compendium = await _context.Compendium.FindAsync(id);
            _context.Compendium.Remove(compendium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompendiumExists(int id)
        {
            return _context.Compendium.Any(e => e.Id == id);
        }
    }
}
