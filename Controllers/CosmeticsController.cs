using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharma_Ky.Data;
using Pharma_Ky.Models;

namespace Pharma_Ky.Controllers
{
    public class CosmeticsController : Controller
    {
        private readonly Pharma_KyContext _context;

        public CosmeticsController(Pharma_KyContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {

            return View();
        }
        // GET: Cosmetics
        public async Task<IActionResult> Index()
        {
              return _context.Cosmetics != null ? 
                          View(await _context.Cosmetics.ToListAsync()) :
                          Problem("Entity set 'Pharma_KyContext.Cosmetics'  is null.");
        }

        // GET: Cosmetics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cosmetics == null)
            {
                return NotFound();
            }

            var cosmetics = await _context.Cosmetics
                .FirstOrDefaultAsync(m => m.CosmeticsId == id);
            if (cosmetics == null)
            {
                return NotFound();
            }

            return View(cosmetics);
        }

        // GET: Cosmetics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cosmetics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CosmeticsId,Cosmeticsname,Cosmeticsdescription,Cosmeticsprice,Cosmeticsimageurl")] Cosmetics cosmetics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cosmetics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: Cosmetics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cosmetics == null)
            {
                return NotFound();
            }

            var cosmetics = await _context.Cosmetics.FindAsync(id);
            if (cosmetics == null)
            {
                return NotFound();
            }
            return View(cosmetics);
        }

        // POST: Cosmetics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CosmeticsId,Cosmeticsname,Cosmeticsdescription,Cosmeticsprice,Cosmeticsimageurl")] Cosmetics cosmetics)
        {
            if (id != cosmetics.CosmeticsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cosmetics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CosmeticsExists(cosmetics.CosmeticsId))
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
            return View(cosmetics);
        }

        // GET: Cosmetics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cosmetics == null)
            {
                return NotFound();
            }

            var cosmetics = await _context.Cosmetics
                .FirstOrDefaultAsync(m => m.CosmeticsId == id);
            if (cosmetics == null)
            {
                return NotFound();
            }

            return View(cosmetics);
        }

        // POST: Cosmetics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cosmetics == null)
            {
                return Problem("Entity set 'Pharma_KyContext.Cosmetics'  is null.");
            }
            var cosmetics = await _context.Cosmetics.FindAsync(id);
            if (cosmetics != null)
            {
                _context.Cosmetics.Remove(cosmetics);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CosmeticsExists(int id)
        {
          return (_context.Cosmetics?.Any(e => e.CosmeticsId == id)).GetValueOrDefault();
        }
    }
}
