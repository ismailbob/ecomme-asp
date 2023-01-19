using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetE_comm.Data;
using ProjetE_comm.Models;

namespace ProjetE_comm.Controllers
{
    public class LignepaniersController : Controller
    {
        private readonly ProjetE_commContext _context;

        public LignepaniersController(ProjetE_commContext context)
        {
            _context = context;
        }

        // GET: Lignepaniers
        public async Task<IActionResult> Index()
        {
            var projetE_commContext = _context.Lignepanier.Include(l => l.Commande).Include(l => l.Product);
            return View(await projetE_commContext.ToListAsync());
        }

        // GET: Lignepaniers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lignepanier == null)
            {
                return NotFound();
            }

            var lignepanier = await _context.Lignepanier
                .Include(l => l.Commande)
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lignepanier == null)
            {
                return NotFound();
            }

            return View(lignepanier);
        }

        // GET: Lignepaniers/Create
        public IActionResult Create()
        {
            ViewData["CommandeId"] = new SelectList(_context.Commande, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: Lignepaniers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,quantite,ProductId,CommandeId")] Lignepanier lignepanier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lignepanier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommandeId"] = new SelectList(_context.Commande, "Id", "Id", lignepanier.CommandeId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", lignepanier.ProductId);
            return View(lignepanier);
        }

        // GET: Lignepaniers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lignepanier == null)
            {
                return NotFound();
            }

            var lignepanier = await _context.Lignepanier.FindAsync(id);
            if (lignepanier == null)
            {
                return NotFound();
            }
            ViewData["CommandeId"] = new SelectList(_context.Commande, "Id", "Id", lignepanier.CommandeId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", lignepanier.ProductId);
            return View(lignepanier);
        }

        // POST: Lignepaniers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,quantite,ProductId,CommandeId")] Lignepanier lignepanier)
        {
            if (id != lignepanier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lignepanier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LignepanierExists(lignepanier.Id))
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
            ViewData["CommandeId"] = new SelectList(_context.Commande, "Id", "Id", lignepanier.CommandeId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", lignepanier.ProductId);
            return View(lignepanier);
        }

        // GET: Lignepaniers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lignepanier == null)
            {
                return NotFound();
            }

            var lignepanier = await _context.Lignepanier
                .Include(l => l.Commande)
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lignepanier == null)
            {
                return NotFound();
            }

            return View(lignepanier);
        }

        // POST: Lignepaniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lignepanier == null)
            {
                return Problem("Entity set 'ProjetE_commContext.Lignepanier'  is null.");
            }
            var lignepanier = await _context.Lignepanier.FindAsync(id);
            if (lignepanier != null)
            {
                _context.Lignepanier.Remove(lignepanier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LignepanierExists(int id)
        {
          return _context.Lignepanier.Any(e => e.Id == id);
        }
    }
}
