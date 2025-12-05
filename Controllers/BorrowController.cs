using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModels;

namespace LibraryManagementSystem.Controllers
{
    public interface IBorrowController
    {
        Task<IActionResult> Index();
        IActionResult Create();
        Task<IActionResult> Create(Borrow borrow);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, Borrow borrow);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
        Task<IActionResult> Details(int? id);
    }

    public interface IBorrowController1
    {
        IActionResult Create();
        Task<IActionResult> Create(Borrow borrow);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
        Task<IActionResult> Details(int? id);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, Borrow borrow);
        Task<IActionResult> Index();
        Task<IActionResult> ViewBorrowBook();
    }

    public interface IBorrowController2
    {
        IActionResult Create();
        Task<IActionResult> Create(Borrow borrow);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
        Task<IActionResult> Details(int? id);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, Borrow borrow);
        Task<IActionResult> Index();
        Task<IActionResult> ViewBorrowBook();
    }

    public interface IBorrowController3
    {
        IActionResult Create();
        Task<IActionResult> Create(Borrow borrow);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
        Task<IActionResult> Details(int? id);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, Borrow borrow);
        Task<IActionResult> Index();
        Task<IActionResult> Return(int? id);
        Task<IActionResult> ReturnConfirmed(int id);
        Task<IActionResult> ViewBorrowBook();
    }

    public class BorrowController : Controller, IBorrowController, IBorrowController1, IBorrowController2, IBorrowController3
    {
        private readonly LibraryDbContext _context;

        public BorrowController(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ViewBorrowBook()
        {
            var borrowRecords = await _context.Borrows
                .Include(b => b.Customer)
                .Include(b => b.Book)
                .Where(b => b.Customer != null && b.Book != null) // filter nulls if any
                .Select(b => new BorrowViewModel
                {
                    Id = b.Id,
                    CustomerName = b.Customer!.Name,
                    BookTitle = b.Book!.Title,
                    BorrowDateTime = b.BorrowDateTime
                })
                .ToListAsync();

            return View(borrowRecords);
        }



        // GET: Borrow
        public async Task<IActionResult> Index()
        {
            var borrows = _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Customer);
            return View(await borrows.ToListAsync());
        }

        // GET: Borrow/Create
        public IActionResult Create()
        {
            ViewData["Books"] = new SelectList(_context.Books, "Id", "Title");
            ViewData["Customers"] = new SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        // POST: Borrow/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                var indiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                var indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, indiaTimeZone);

                borrow.BorrowDateTime = indianTime;


                _context.Add(borrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ViewBorrowBook));
            }
            ViewData["Books"] = new SelectList(_context.Books, "Id", "Title", borrow.BookId);
            ViewData["Customers"] = new SelectList(_context.Customers, "Id", "Name", borrow.CustomerId);
            return View(borrow);
        }


        // GET: Borrow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null) return NotFound();

            ViewData["Books"] = new SelectList(_context.Books, "Id", "Title", borrow.BookId);
            ViewData["Customers"] = new SelectList(_context.Customers, "Id", "Name", borrow.CustomerId);
            return View(borrow);
        }

        // POST: Borrow/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Borrow borrow)
        {
            if (id != borrow.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Borrows.Any(e => e.Id == borrow.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(ViewBorrowBook));
            }
            ViewData["Books"] = new SelectList(_context.Books, "Id", "Title", borrow.BookId);
            ViewData["Customers"] = new SelectList(_context.Customers, "Id", "Name", borrow.CustomerId);
            return View(borrow);
        }

        // GET: Borrow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var borrow = await _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrow == null) return NotFound();

            return View(borrow);
        }

        // POST: Borrow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow != null)
            {
                _context.Borrows.Remove(borrow);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ViewBorrowBook));
        }

        // GET: Borrow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var borrow = await _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (borrow == null) return NotFound();

            return View(borrow);
        }

        // GET: Borrow/Return/5
        public async Task<IActionResult> Return(int? id)
        {
            if (id == null)
                return NotFound();

            var borrow = await _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (borrow == null)
                return NotFound();

            return View(borrow);
        }

        // POST: Borrow/Return/5
        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnConfirmed(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow != null)
            {
                borrow.ReturnDate = DateTime.Now;
                _context.Update(borrow);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ViewBorrowBook));
        }
    }
}
