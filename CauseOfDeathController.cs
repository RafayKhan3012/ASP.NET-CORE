using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Controllers
{
    public class CauseOfDeathController : Controller
    {
        private readonly LocalDBContext _context;

        public CauseOfDeathController(LocalDBContext context)
        {
            _context = context;
        }

        // GET: CauseOfDeath
        public async Task<IActionResult> Index()
        {
            int[] Ids = _context.tbl_CauseOfDeath.Select(x => x.ID).ToArray();
            var Session = HttpContext.Session.GetString("User");
            return View(await _context.tbl_CauseOfDeath.ToListAsync());
        }

        // GET: CauseOfDeath/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_CauseOfDeath = await _context.tbl_CauseOfDeath
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbl_CauseOfDeath == null)
            {
                return NotFound();
            }

            return View(tbl_CauseOfDeath);
        }

        // GET: CauseOfDeath/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CauseOfDeath/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Cause,FK_User")] tbl_CauseOfDeath tbl_CauseOfDeath)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbl_CauseOfDeath);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbl_CauseOfDeath);
        }

        // GET: CauseOfDeath/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_CauseOfDeath = await _context.tbl_CauseOfDeath.FindAsync(id);
            if (tbl_CauseOfDeath == null)
            {
                return NotFound();
            }
            return View(tbl_CauseOfDeath);
        }

        // POST: CauseOfDeath/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Cause,FK_User")] tbl_CauseOfDeath tbl_CauseOfDeath)
        {
            if (id != tbl_CauseOfDeath.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbl_CauseOfDeath);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_CauseOfDeathExists(tbl_CauseOfDeath.ID))
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
            return View(tbl_CauseOfDeath);
        }

        // GET: CauseOfDeath/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbl_CauseOfDeath = await _context.tbl_CauseOfDeath
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbl_CauseOfDeath == null)
            {
                return NotFound();
            }

            return View(tbl_CauseOfDeath);
        }

        // POST: CauseOfDeath/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbl_CauseOfDeath = await _context.tbl_CauseOfDeath.FindAsync(id);
            _context.tbl_CauseOfDeath.Remove(tbl_CauseOfDeath);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbl_CauseOfDeathExists(int id)
        {
            return _context.tbl_CauseOfDeath.Any(e => e.ID == id);
        }
    }
}
