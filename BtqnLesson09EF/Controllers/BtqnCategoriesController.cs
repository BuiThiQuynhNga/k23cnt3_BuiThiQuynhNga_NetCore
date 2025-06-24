using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BtqnLesson09EF.Models;

namespace BtqnLesson09EF.Controllers
{
    public class BtqnCategoriesController : Controller
    {
        private readonly BtqnBookStoreContext _context;

        public BtqnCategoriesController(BtqnBookStoreContext context)
        {
            _context = context;
        }

        // GET: BtqnCategories
        public async Task<IActionResult> BtqnIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: BtqnCategories/Details/5
        public async Task<IActionResult> Details(int? btqnId)
        {
            if (btqnId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == btqnId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: BtqnCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BtqnCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(BtqnIndex));
            }
            return View(category);
        }

        // GET: BtqnCategories/Edit/5
        public async Task<IActionResult> Edit(int? btqnId)
        {
            if (btqnId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(btqnId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: BtqnCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int btqnId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (btqnId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: BtqnCategories/Delete/5
        public async Task<IActionResult> Delete(int? btqnId)
        {
            if (btqnId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == btqnId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: BtqnCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int btqnId)
        {
            var category = await _context.Categories.FindAsync(btqnId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BtqnIndex));
        }

        private bool CategoryExists(int btqnId)
        {
            return _context.Categories.Any(e => e.CategoryId == btqnId);
        }
    }
}
