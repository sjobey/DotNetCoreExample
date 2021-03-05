using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeLosRiosCredit.Models;

namespace DeLosRiosCredit.Controllers
{
    public class CreditApplicationsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CreditApplicationsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: CreditApplications
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.CreditApplications.Include(c => c.Applicant).Include(c => c.Status);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: CreditApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditApplication = await _context.CreditApplications
                .Include(c => c.Applicant)
                .Include(c => c.Status)
                .FirstOrDefaultAsync(m => m.CreditApplicationId == id);
            if (creditApplication == null)
            {
                return NotFound();
            }

            return View(creditApplication);
        }

        // GET: CreditApplications/Create
        public IActionResult Create()
        {
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "LastName");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name");
            return View();
        }

        // POST: CreditApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditApplicationId,LoanAmount,APR,TermMonths,Product,ApplicantId,StatusId")] CreditApplication creditApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", creditApplication.ApplicantId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", creditApplication.StatusId);
            return View(creditApplication);
        }

        // GET: CreditApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditApplication = await _context.CreditApplications.FindAsync(id);
            if (creditApplication == null)
            {
                return NotFound();
            }
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", creditApplication.ApplicantId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", creditApplication.StatusId);
            return View(creditApplication);
        }

        // POST: CreditApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditApplicationId,LoanAmount,APR,TermMonths,Product,ApplicantId,StatusId")] CreditApplication creditApplication)
        {
            if (id != creditApplication.CreditApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditApplicationExists(creditApplication.CreditApplicationId))
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
            ViewData["ApplicantId"] = new SelectList(_context.Applicants, "ApplicantId", "ApplicantId", creditApplication.ApplicantId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", creditApplication.StatusId);
            return View(creditApplication);
        }

        // GET: CreditApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditApplication = await _context.CreditApplications
                .Include(c => c.Applicant)
                .Include(c => c.Status)
                .FirstOrDefaultAsync(m => m.CreditApplicationId == id);
            if (creditApplication == null)
            {
                return NotFound();
            }

            return View(creditApplication);
        }

        // POST: CreditApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditApplication = await _context.CreditApplications.FindAsync(id);
            _context.CreditApplications.Remove(creditApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditApplicationExists(int id)
        {
            return _context.CreditApplications.Any(e => e.CreditApplicationId == id);
        }
    }
}
