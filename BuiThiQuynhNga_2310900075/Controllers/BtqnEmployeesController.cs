using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuiThiQuynhNga_2310900075.Models;

namespace BuiThiQuynhNga_2310900075.Controllers
{
    public class BtqnEmployeeController : Controller
    {
        private readonly BuiThiQuynhNga2310900075Context _context;

        public BtqnEmployeeController(BuiThiQuynhNga2310900075Context context)
        {
            _context = context;
        }

        // GET: BtqnEmployee/BtqnIndex
        public async Task<IActionResult> BtqnIndex()
        {
            var list = await _context.BtqnEmployees.ToListAsync();
            return View(list);
        }

        // GET: BtqnEmployee/BtqnDetails/5
        public async Task<IActionResult> BtqnDetails(int? id)
        {
            if (id == null) return NotFound();

            var emp = await _context.BtqnEmployees.FirstOrDefaultAsync(m => m.BtqnEmpld == id);
            if (emp == null) return NotFound();

            return View(emp);
        }

        // GET: BtqnEmployee/BtqnCreate
        public IActionResult BtqnCreate()
        {
            return View();
        }

        // POST: BtqnEmployee/BtqnCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BtqnCreate([Bind("BtqnEmpld,BtqnEmpName,BtqnEmpLevel,BtqnEmpStartDate,BtqnEmpStatus")] BtqnEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(BtqnIndex));
            }
            return View(emp);
        }

        // GET: BtqnEmployee/BtqnEdit/5
        public async Task<IActionResult> BtqnEdit(int? id)
        {
            if (id == null) return NotFound();

            var emp = await _context.BtqnEmployees.FindAsync(id);
            if (emp == null) return NotFound();

            return View(emp);
        }

        // POST: BtqnEmployee/BtqnEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BtqnEdit(int id, [Bind("BtqnEmpld,BtqnEmpName,BtqnEmpLevel,BtqnEmpStartDate,BtqnEmpStatus")] BtqnEmployee emp)
        {
            if (id != emp.BtqnEmpld) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BtqnEmployeeExists(emp.BtqnEmpld)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(BtqnIndex));
            }
            return View(emp);
        }

        // GET: BtqnEmployee/BtqnDelete/5
        public async Task<IActionResult> BtqnDelete(int? id)
        {
            if (id == null) return NotFound();

            var emp = await _context.BtqnEmployees.FirstOrDefaultAsync(m => m.BtqnEmpld == id);
            if (emp == null) return NotFound();

            return View(emp);
        }

        // POST: BtqnEmployee/BtqnDelete/5
        [HttpPost, ActionName("BtqnDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BtqnDeleteConfirmed(int id)
        {
            var emp = await _context.BtqnEmployees.FindAsync(id);
            if (emp != null)
            {
                _context.BtqnEmployees.Remove(emp);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(BtqnIndex));
        }

        private bool BtqnEmployeeExists(int id)
        {
            return _context.BtqnEmployees.Any(e => e.BtqnEmpld == id);
        }
    }
}
