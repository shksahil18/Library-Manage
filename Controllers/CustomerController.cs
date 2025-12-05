using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public interface ICustomerController
    {
        IActionResult Create();
        Task<IActionResult> Create(Customer customer);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
        Task<IActionResult> Details(int? id);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, Customer customer);
        Task<IActionResult> Index();
    }

    public interface ICustomerController1
    {
        IActionResult Create();
        Task<IActionResult> Create(Customer customer);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
        Task<IActionResult> Details(int? id);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, Customer customer);
        Task<IActionResult> Index();
    }

    public interface ICustomerController2
    {
        IActionResult BorrowBook();
        IActionResult BorrowBook(BorrowModel model);
        IActionResult Create();
        Task<IActionResult> Create(Customer customer);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
        Task<IActionResult> Details(int? id);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, Customer customer);
        Task<IActionResult> Index();
    }

    public class CustomerController : Controller, ICustomerController, ICustomerController1, ICustomerController2
    {
        private readonly LibraryDbContext _context;

        public CustomerController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        public IActionResult BorrowBook()
        {
            var viewModel = new BorrowModel
            {
                BorrowDate = DateTime.Now,
                CustomerList = _context.Customers
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList(),
                BookList = _context.Books
                    .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Title }).ToList()
            };

            return View(viewModel);
        }

        // POST: Customer/BorrowBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BorrowBook(BorrowModel model)
        {
            if (ModelState.IsValid)
            {
                var borrow = new Borrow
                {
                    CustomerId = model.CustomerId,
                    BookId = model.BookId,
                    BorrowDateTime = model.BorrowDate
                };

                _context.Borrows.Add(borrow);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // Reload dropdowns if model is invalid
            model.CustomerList = _context.Customers
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            model.BookList = _context.Books
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Title }).ToList();

            return View(model);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();

            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Customers.Any(e => e.Id == customer.Id))
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
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null) return NotFound();

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null) return NotFound();

            return View(customer);
        }
    }
}
