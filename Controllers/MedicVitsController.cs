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
    public class MedicVitsController : Controller
    {
        private readonly Pharma_KyContext _context;

        public MedicVitsController(Pharma_KyContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {

            return View();
        }
        // GET: MedicVits
        public async Task<IActionResult> Index()
        {
              return _context.MedicVits != null ? 
                          View(await _context.MedicVits.ToListAsync()) :
                          Problem("Entity set 'Pharma_KyContext.MedicVits'  is null.");
        }

        // GET: MedicVits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicVits == null)
            {
                return NotFound();
            }

            var medicVits = await _context.MedicVits
                .FirstOrDefaultAsync(m => m.MedicVitId == id);
            if (medicVits == null)
            {
                return NotFound();
            }

            return View(medicVits);
        }

        // GET: MedicVits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicVits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicVitId,MedicVitname,MedicVitdescription,MedicVitprice,MedicVitimageurl")] MedicVits medicVits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicVits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicVits);
        }

        // GET: MedicVits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicVits == null)
            {
                return NotFound();
            }

            var medicVits = await _context.MedicVits.FindAsync(id);
            if (medicVits == null)
            {
                return NotFound();
            }
            return View(medicVits);
        }

        // POST: MedicVits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicVitId,MedicVitname,MedicVitdescription,MedicVitprice,MedicVitimageurl")] MedicVits medicVits)
        {
            if (id != medicVits.MedicVitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicVits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicVitsExists(medicVits.MedicVitId))
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
            return View(medicVits);
        }

        // GET: MedicVits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicVits == null)
            {
                return NotFound();
            }

            var medicVits = await _context.MedicVits
                .FirstOrDefaultAsync(m => m.MedicVitId == id);
            if (medicVits == null)
            {
                return NotFound();
            }

            return View(medicVits);
        }

        // POST: MedicVits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicVits == null)
            {
                return Problem("Entity set 'Pharma_KyContext.MedicVits'  is null.");
            }
            var medicVits = await _context.MedicVits.FindAsync(id);
            if (medicVits != null)
            {
                _context.MedicVits.Remove(medicVits);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicVitsExists(int id)
        {
          return (_context.MedicVits?.Any(e => e.MedicVitId == id)).GetValueOrDefault();
        }
    }
}
