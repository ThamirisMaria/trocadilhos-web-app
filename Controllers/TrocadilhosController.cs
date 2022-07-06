using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrocadilhosWebApp.Data;
using TrocadilhosWebApp.Models;

namespace TrocadilhosWebApp.Controllers
{
    public class TrocadilhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrocadilhosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trocadilhos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trocadilho.ToListAsync());
        }

        // GET: Trocadilhos/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Trocadilhos/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchTerm)
        {
            return View("Index", await _context.Trocadilho.Where(j => j.TrocadilhoQuestion.Contains(SearchTerm)).ToListAsync());
        }

        // GET: Trocadilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trocadilho = await _context.Trocadilho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trocadilho == null)
            {
                return NotFound();
            }

            return View(trocadilho);
        }

        // GET: Trocadilhos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trocadilhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrocadilhoQuestion,TrocadilhoAnswer")] Trocadilho trocadilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trocadilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trocadilho);
        }

        // GET: Trocadilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trocadilho = await _context.Trocadilho.FindAsync(id);
            if (trocadilho == null)
            {
                return NotFound();
            }
            return View(trocadilho);
        }

        // POST: Trocadilhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrocadilhoQuestion,TrocadilhoAnswer")] Trocadilho trocadilho)
        {
            if (id != trocadilho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trocadilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrocadilhoExists(trocadilho.Id))
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
            return View(trocadilho);
        }

        // GET: Trocadilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trocadilho = await _context.Trocadilho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trocadilho == null)
            {
                return NotFound();
            }

            return View(trocadilho);
        }

        // POST: Trocadilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trocadilho = await _context.Trocadilho.FindAsync(id);
            _context.Trocadilho.Remove(trocadilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrocadilhoExists(int id)
        {
            return _context.Trocadilho.Any(e => e.Id == id);
        }
    }
}
