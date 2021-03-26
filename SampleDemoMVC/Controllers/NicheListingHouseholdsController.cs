using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleDemoMVC.Models;

namespace SampleDemoMVC.Controllers
{
    public class NicheListingHouseholdsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NicheListingHouseholdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NicheListingHouseholds
        public async Task<IActionResult> Index()
        {
            return View(await _context.NicheListingHouseholds.ToListAsync());
        }

        // GET: NicheListingHouseholds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nicheListingHousehold = await _context.NicheListingHouseholds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nicheListingHousehold == null)
            {
                return NotFound();
            }

            return View(nicheListingHousehold);
        }

        // GET: NicheListingHouseholds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NicheListingHouseholds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HouseholdId,HasPregnantWomanId,HasEligibleChildrenId,PregnantWomenNumber,EligibleChildrenNumber,StatusId,EnumeratorId,RegistrationEnumeratorId,SubmittedOn,Longitude,Latitude,RejectionReasonId,OtherRejectionReason,ApprovalNotes")] NicheListingHousehold nicheListingHousehold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nicheListingHousehold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nicheListingHousehold);
        }

        // GET: NicheListingHouseholds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nicheListingHousehold = await _context.NicheListingHouseholds.FindAsync(id);
            if (nicheListingHousehold == null)
            {
                return NotFound();
            }
            return View(nicheListingHousehold);
        }

        // POST: NicheListingHouseholds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HouseholdId,HasPregnantWomanId,HasEligibleChildrenId,PregnantWomenNumber,EligibleChildrenNumber,StatusId,EnumeratorId,RegistrationEnumeratorId,SubmittedOn,Longitude,Latitude,RejectionReasonId,OtherRejectionReason,ApprovalNotes")] NicheListingHousehold nicheListingHousehold)
        {
            if (id != nicheListingHousehold.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nicheListingHousehold);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NicheListingHouseholdExists(nicheListingHousehold.Id))
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
            return View(nicheListingHousehold);
        }

        // GET: NicheListingHouseholds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nicheListingHousehold = await _context.NicheListingHouseholds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nicheListingHousehold == null)
            {
                return NotFound();
            }

            return View(nicheListingHousehold);
        }

        // POST: NicheListingHouseholds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nicheListingHousehold = await _context.NicheListingHouseholds.FindAsync(id);
            _context.NicheListingHouseholds.Remove(nicheListingHousehold);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NicheListingHouseholdExists(int id)
        {
            return _context.NicheListingHouseholds.Any(e => e.Id == id);
        }
    }
}
