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
    public class HouseholdMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HouseholdMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HouseholdMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.HouseHoldMembers.ToListAsync());
        }

        // GET: HouseholdMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var householdMembers = await _context.HouseHoldMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (householdMembers == null)
            {
                return NotFound();
            }

            return View(householdMembers);
        }

        // GET: HouseholdMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseholdMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,StatusId,RelationshipId,MemberRoleId,SourceId,Surname,NationalIdNo,MobileNo2,Dob,BirthCertNo,HouseholdId")] HouseholdMembers householdMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(householdMembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(householdMembers);
        }

        // GET: HouseholdMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var householdMembers = await _context.HouseHoldMembers.FindAsync(id);
            if (householdMembers == null)
            {
                return NotFound();
            }
            return View(householdMembers);
        }

        // POST: HouseholdMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,StatusId,RelationshipId,MemberRoleId,SourceId,Surname,NationalIdNo,MobileNo2,Dob,BirthCertNo,HouseholdId")] HouseholdMembers householdMembers)
        {
            if (id != householdMembers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(householdMembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseholdMembersExists(householdMembers.Id))
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
            return View(householdMembers);
        }

        // GET: HouseholdMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var householdMembers = await _context.HouseHoldMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (householdMembers == null)
            {
                return NotFound();
            }

            return View(householdMembers);
        }

        // POST: HouseholdMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var householdMembers = await _context.HouseHoldMembers.FindAsync(id);
            _context.HouseHoldMembers.Remove(householdMembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseholdMembersExists(int id)
        {
            return _context.HouseHoldMembers.Any(e => e.Id == id);
        }
    }
}
