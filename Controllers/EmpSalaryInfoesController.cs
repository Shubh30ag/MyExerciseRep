using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMVCWithAzureDatabase.Models;

namespace CoreMVCWithAzureDatabase.Controllers
{
    public class EmpSalaryInfoesController : Controller
    {
        private readonly EmpDatabaseContext _context;

        public EmpSalaryInfoesController(EmpDatabaseContext context)
        {
            _context = context;
        }

        // GET: EmpSalaryInfoes
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.EmpSalaryInfo.ToListAsync());
        }

        // GET: EmpSalaryInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empSalaryInfo = await _context.EmpSalaryInfo
                .FirstOrDefaultAsync(m => m.PayBand == id);
            if (empSalaryInfo == null)
            {
                return NotFound();
            }

            return View(empSalaryInfo);
        }

        // GET: EmpSalaryInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpSalaryInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayBand,BasicSalary")] EmpSalaryInfo empSalaryInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empSalaryInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empSalaryInfo);
        }

        // GET: EmpSalaryInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empSalaryInfo = await _context.EmpSalaryInfo.FindAsync(id);
            if (empSalaryInfo == null)
            {
                return NotFound();
            }
            return View(empSalaryInfo);
        }

        // POST: EmpSalaryInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PayBand,BasicSalary")] EmpSalaryInfo empSalaryInfo)
        {
            if (id != empSalaryInfo.PayBand)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empSalaryInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpSalaryInfoExists(empSalaryInfo.PayBand))
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
            return View(empSalaryInfo);
        }

        // GET: EmpSalaryInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empSalaryInfo = await _context.EmpSalaryInfo
                .FirstOrDefaultAsync(m => m.PayBand == id);
            if (empSalaryInfo == null)
            {
                return NotFound();
            }

            return View(empSalaryInfo);
        }

        // POST: EmpSalaryInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var empSalaryInfo = await _context.EmpSalaryInfo.FindAsync(id);
            _context.EmpSalaryInfo.Remove(empSalaryInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpSalaryInfoExists(string id)
        {
            return _context.EmpSalaryInfo.Any(e => e.PayBand == id);
        }
    }
}
