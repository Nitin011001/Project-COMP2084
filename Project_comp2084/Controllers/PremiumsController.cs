using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_comp2084.Data;
using Project_comp2084.Models;

namespace Project_comp2084.Controllers
{
    public class PremiumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PremiumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Premiums
        public async Task<IActionResult> Index()
        {
              return _context.Premium != null ? 
                          View(await _context.Premium.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Premium'  is null.");
        }

        // GET: Premiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium = await _context.Premium
                .FirstOrDefaultAsync(m => m.Id == id);
            if (premium == null)
            {
                return NotFound();
            }
           var pack=_context.Packages.Where(p=>p.PremiumId== id).OrderBy(packs=>packs.Price);

            var viewModal = new PremiumViewModel()
            {
                Name = premium.Name,
                Id = premium.Id,
                Description = premium.Description,
                package = pack.ToList()
            };

            return View(viewModal);
        }
        [Authorize]
        // GET: Premiums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Premiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Premium premium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(premium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(premium);
        }
        [Authorize]
        // GET: Premiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium = await _context.Premium.FindAsync(id);
            if (premium == null)
            {
                return NotFound();
            }
            return View(premium);
        }

        // POST: Premiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Premium premium)
        {
            if (id != premium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(premium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PremiumExists(premium.Id))
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
            return View(premium);
        }
        [Authorize]
        // GET: Premiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium = await _context.Premium
                .FirstOrDefaultAsync(m => m.Id == id);
            if (premium == null)
            {
                return NotFound();
            }

            return View(premium);
        }

        // POST: Premiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Premium == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Premium'  is null.");
            }
            var premium = await _context.Premium.FindAsync(id);
            if (premium != null)
            {
                _context.Premium.Remove(premium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PremiumExists(int id)
        {
          return (_context.Premium?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

    public class PremiumViewModel
    {
        
        public int Id { get; set; }
    
        public string Name { get; set; }
   
        public string Description { get; set; }

        public ICollection<Packages>? package { get; set; }
    }
}
