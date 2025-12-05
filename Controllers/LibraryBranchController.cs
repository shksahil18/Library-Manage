using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public interface ILibraryBranchController
    {
        IActionResult Create();
        Task<IActionResult> Create(LibraryBranch branch);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
        Task<IActionResult> Details(int id);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, LibraryBranch branch);
        Task<IActionResult> Index();
    }

    public class LibraryBranchController : Controller, ILibraryBranchController
    {
        private readonly LibraryDbContext _context;

        public LibraryBranchController(LibraryDbContext context)
        {
            _context = context;
        }

        // Index: Optional, include books if needed in table
        public async Task<IActionResult> Index()
        {
            var branches = await _context.LibraryBranches
                .Include(b => b.Books)
                .ToListAsync();

            return View(branches);
        }

        // Details: Include books in one branch
        public async Task<IActionResult> Details(int id)
        {
            var branch = await _context.LibraryBranches
                .Include(b => b.Books)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (branch == null)
                return NotFound();

            return View(branch);
        }


        // GET: LibraryBranch/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibraryBranch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibraryBranch branch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // GET: LibraryBranch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var branch = await _context.LibraryBranches.FindAsync(id);
            if (branch == null) return NotFound();

            return View(branch);
        }

        // POST: LibraryBranch/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LibraryBranch branch)
        {
            if (id != branch.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryBranchExists(branch.Id))
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
            return View(branch);
        }

        // GET: LibraryBranch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var branch = await _context.LibraryBranches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branch == null) return NotFound();

            return View(branch);
        }

        // POST: LibraryBranch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _context.LibraryBranches.FindAsync(id);
            if (branch != null)
            {
                _context.LibraryBranches.Remove(branch);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryBranchExists(int id)
        {
            return _context.LibraryBranches.Any(e => e.Id == id);
        }
    }
}
