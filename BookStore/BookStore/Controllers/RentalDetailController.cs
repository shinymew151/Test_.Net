using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class RentalDetailController : Controller
    {
        private readonly ComicStoreDatabaseContext _context;

        public RentalDetailController(ComicStoreDatabaseContext context)
        {
            _context = context;
        }

        // GET: RentalDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalDetails.ToListAsync());
        }

        // GET: RentalDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalDetails = await _context.RentalDetails
                .FirstOrDefaultAsync(m => m.RentalDetailId == id);
            if (rentalDetails == null)
            {
                return NotFound();
            }

            return View(rentalDetails);
        }

        // GET: RentalDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalDetailId,RentalId,ComicBookId,PricePerDay")] RentalDetails rentalDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalDetails);
        }

        // GET: RentalDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalDetails = await _context.RentalDetails.FindAsync(id);
            if (rentalDetails == null)
            {
                return NotFound();
            }
            return View(rentalDetails);
        }

        // POST: RentalDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalDetailId,RentalId,ComicBookId,PricePerDay")] RentalDetails rentalDetails)
        {
            if (id != rentalDetails.RentalDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalDetailsExists(rentalDetails.RentalDetailId))
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
            return View(rentalDetails);
        }

        // GET: RentalDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalDetails = await _context.RentalDetails
                .FirstOrDefaultAsync(m => m.RentalDetailId == id);
            if (rentalDetails == null)
            {
                return NotFound();
            }

            return View(rentalDetails);
        }

        // POST: RentalDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalDetails = await _context.RentalDetails.FindAsync(id);
            if (rentalDetails != null)
            {
                _context.RentalDetails.Remove(rentalDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalDetailsExists(int id)
        {
            return _context.RentalDetails.Any(e => e.RentalDetailId == id);
        }
    }
}
