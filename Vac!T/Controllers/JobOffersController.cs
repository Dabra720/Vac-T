using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vac_T.Contexts;
using Vac_T.Models;
using Microsoft.AspNetCore.Identity;
using Vac_T.Areas.Identity.Data;
using System.Collections.Immutable;

namespace Vac_T.Controllers
{
    public class JobOffersController : Controller
    {
        private readonly VacItContext _context;

        public JobOffersController(VacItContext context)
        {
            _context = context;
        }

        // GET: JobOffers
        public async Task<IActionResult> Index()
        {
            if (_context.JobOffers == null) return Problem("Entity set 'VacItContext is null'");

            // Filter for Employers (Only own offers)
            if (User.IsInRole("ROLE_EMPLOYER")) {
                //var user = await _context.Users.Where(u => u.Email == User.Identity.Name).FirstAsync();

                var currentUser = _context.Users.First(u => u.UserName == User.Identity.Name);
                
                var companyId = currentUser.CompanyId;

                var jobOffers = await _context.JobOffers
                    .Where(jo => jo.CompanyId == companyId)
                    .ToListAsync();

                return View(jobOffers);
            }

            return View(await _context.JobOffers.ToListAsync());

            /*if (User.IsInRole("Admin")) { }
              return _context.JobOffers != null ? 
                          View(await _context.JobOffers.ToListAsync()) :
                          Problem("Entity set 'VacItContext.JobOffers'  is null.");*/
        }

        // GET: JobOffers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobOffers == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers
                .Include("Company")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            else
            {
                if (User.IsInRole("ROLE_CANDIDATE") || User.IsInRole("Admin"))
                {
                    jobOffer.Company.JobOffers = _context.JobOffers
                        .Where(j => j.CompanyId == jobOffer.CompanyId && j.Id != jobOffer.Id).ToList();
                }
                if(User.IsInRole("ROLE_EMPLOYER") || User.IsInRole("Admin"))
                {
                    jobOffer.UserJobOffers = _context.UserJobOffers
                        .Where(j => j.JobOfferId == jobOffer.Id)
                        .Include("User")
                        .ToList();
                }
            }

            return View(jobOffer);
        }

        // GET: JobOffers/Create
        [Authorize(Roles = "ROLE_EMPLOYER, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobOffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ROLE_EMPLOYER")]
        public async Task<IActionResult> Create([Bind("Id,Date,Title,Description,Level")] JobOffer jobOffer)
        {
            var currentUser = _context.Users
                .Include("Company")
                .First(u => u.UserName == User.Identity.Name);
            //jobOffer.CompanyId = (int)currentUser.CompanyId;
            jobOffer.Company = currentUser.Company;
            if (ModelState.IsValid)
            {
                _context.Add(jobOffer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } else
            {
                Console.WriteLine("Modelstate not valid");
            }
            return View(jobOffer);
        }

        // GET: JobOffers/Edit/5
        [Authorize(Roles = "Admin, ROLE_EMPLOYER")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobOffers == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            return View(jobOffer);
        }

        // POST: JobOffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ROLE_EMPLOYER")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Title,Description,Level")] JobOffer jobOffer)
        {
            if (id != jobOffer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobOffer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobOfferExists(jobOffer.Id))
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
            return View(jobOffer);
        }

        // GET: JobOffers/Delete/5
        [Authorize(Roles = "Admin, ROLE_EMPLOYER")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobOffers == null)
            {
                return NotFound();
            }

            var jobOffer = await _context.JobOffers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            return View(jobOffer);
        }

        // POST: JobOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ROLE_EMPLOYER")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobOffers == null)
            {
                return Problem("Entity set 'VacItContext.JobOffers'  is null.");
            }
            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer != null)
            {
                _context.JobOffers.Remove(jobOffer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobOfferExists(int id)
        {
          return (_context.JobOffers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
