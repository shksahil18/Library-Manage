using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Data; // Make sure the namespace matches your DbContext location

namespace LibraryManagementSystem.Controllers
{
    public interface IAccountController
    {
        IActionResult Login();
        IActionResult Login(Account account);
        IActionResult Logout();
        IActionResult Register();
        IActionResult Register(Account account);
    }

    public class AccountController : Controller, IAccountController
    {
        private readonly LibraryDbContext _context;

        public AccountController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Account account)
        {
            if (ModelState.IsValid)
            {
                var existingAccount = _context.Accounts.FirstOrDefault(a => a.Email == account.Email);
                if (existingAccount != null)
                {
                    ModelState.AddModelError("", "Email already registered.");
                    return View(account);
                }

                _context.Accounts.Add(account);
                _context.SaveChanges();
                TempData["Success"] = "Registration successful! Please login.";
                return RedirectToAction("Login");
            }

            return View(account);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Account account)
        {
                var user = _context.Accounts
                    .FirstOrDefault(a => a.Email == account.Email && a.Password == account.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString("UserEmail", user.Email); // Store email in session
                    HttpContext.Session.SetString("UserName", user.Name);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid login credentials.";
                    return View();
                }
        }
            
        // Logout 
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session values
            return RedirectToAction("Login");
        }
    }
}
