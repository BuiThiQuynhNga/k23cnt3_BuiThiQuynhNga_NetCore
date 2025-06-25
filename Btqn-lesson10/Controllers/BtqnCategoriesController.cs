using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Btqn_lesson10.Models;

namespace Btqn_lesson10.Controllers
{
    public class BtqnCategoriesController : Controller
    {
        private readonly BtqnK23cnt3Lesson10DbContext _context;

        public BtqnCategoriesController(BtqnK23cnt3Lesson10DbContext context)
        {
            _context = context;
        }

        // GET: BtqnCategories
        public async Task<IActionResult> BtqnIndex()
        {
            return View(await _context.BtqnCategories.ToListAsync());
        }

        // GET: BtqnCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var btqnCategory = await _context.BtqnCategories
                .FirstOrDefaultAsync(m => m.BtqnId == id);
            if (btqnCategory == null)
            {
                return NotFound();
            }

            return View(btqnCategory);
        }

        // GET: BtqnCategories/Create
        public IActionResult BtqnCreate()
        {
            return View();
        }

        // POST: BtqnCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BtqnCreate([Bind("BtqnId,BtqnName,BtqnStatus")] BtqnCategory btqnCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(btqnCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(BtqnIndex));
            }
            return View(btqnCategory);
        }

        // GET: BtqnCategories/Edit/5
        public async Task<IActionResult> BtqnEdit(int? btqnId)
        {
            if (btqnId == null)
            {
                return NotFound();
            }

            var btqnCategory = await _context.BtqnCategories.FindAsync(btqnId);
            if (btqnCategory == null)
            {
                return NotFound();
            }
            return View(btqnCategory);
        }

        // POST: BtqnCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BtqnEdit(int btqnId, [Bind("BtqnId,BtqnName,BtqnStatus")] BtqnCategory btqnCategory)
        {
            if (btqnId != btqnCategory.BtqnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(btqnCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BtqnCategoryExists(btqnCategory.BtqnId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(BtqnIndex));
            }
            return View(btqnCategory);
        }

        // GET: BtqnCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var btqnCategory = await _context.BtqnCategories
                .FirstOrDefaultAsync(m => m.BtqnId == id);
            if (btqnCategory == null)
            {
                return NotFound();
            }

            return View(btqnCategory);
        }

        // POST: BtqnCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var btqnCategory = await _context.BtqnCategories.FindAsync(id);
            if (btqnCategory != null)
            {
                _context.BtqnCategories.Remove(btqnCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BtqnCategoryExists(int id)
        {
            return _context.BtqnCategories.Any(e => e.BtqnId == id);
        }
    }
}
