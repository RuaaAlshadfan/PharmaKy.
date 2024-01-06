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
    public class DevChidsController : Controller
    {
        private readonly Pharma_KyContext _context;

        public DevChidsController(Pharma_KyContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            return View();
        }        
        // GET: DevChids
        public async Task<IActionResult> Index()
        {
              return _context.DevChid != null ? 
                          View(await _context.DevChid.ToListAsync()) :
                          Problem("Entity set 'Pharma_KyContext.DevChid'  is null.");
        }

        // GET: DevChids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DevChid == null)
            {
                return NotFound();
            }

            var devChid = await _context.DevChid
                .FirstOrDefaultAsync(m => m.DevChidId == id);
            if (devChid == null)
            {
                return NotFound();
            }

            return View(devChid);
        }

        // GET: DevChids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DevChids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DevChidId,DevChidname,DevChiddescription,DevChidprice,DevChidimageurl")] DevChid devChid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devChid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(devChid);
        }

        // GET: DevChids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DevChid == null)
            {
                return NotFound();
            }

            var devChid = await _context.DevChid.FindAsync(id);
            if (devChid == null)
            {
                return NotFound();
            }
            return View(devChid);
        }

        // POST: DevChids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevChidId,DevChidname,DevChiddescription,DevChidprice,DevChidimageurl")] DevChid devChid)
        {
            if (id != devChid.DevChidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devChid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevChidExists(devChid.DevChidId))
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
            return View(devChid);
        }

        // GET: DevChids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DevChid == null)
            {
                return NotFound();
            }

            var devChid = await _context.DevChid
                .FirstOrDefaultAsync(m => m.DevChidId == id);
            if (devChid == null)
            {
                return NotFound();
            }

            return View(devChid);
        }

        // POST: DevChids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DevChid == null)
            {
                return Problem("Entity set 'Pharma_KyContext.DevChid'  is null.");
            }
            var devChid = await _context.DevChid.FindAsync(id);
            if (devChid != null)
            {
                _context.DevChid.Remove(devChid);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevChidExists(int id)
        {
          return (_context.DevChid?.Any(e => e.DevChidId == id)).GetValueOrDefault();
        }
    }
}
