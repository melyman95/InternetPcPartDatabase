using InternetPcPartDatabase.Data;
using InternetPcPartDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace InternetPcPartDatabase.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly PartContext _context;

        public UserAccountController(PartContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel reg)
        {
            if (ModelState.IsValid)
            {
                // add the user to database
                // check if email is in use
                bool EmailTaken = await
                    (from UserAccount in _context.UserAccounts
                     where UserAccount.Email == reg.Email
                     select UserAccount).AnyAsync();

                if (EmailTaken)
                {
                    ModelState.AddModelError(nameof(RegisterViewModel.Email), "Email is already associated with an account.");
                    return View(reg);
                }

                UserAccount account = new UserAccount()
                {
                    Email = reg.Email,
                    Password = reg.Password
                };

                // adds user to database
                await _context.UserAccounts.AddAsync(account);
                await _context.SaveChangesAsync();
            }
            return View(reg);
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Check to see if user is logged in already
            if (HttpContext.Session.GetInt32("UserId").HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                UserAccount account =
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                await (from user in _context.UserAccounts
                       where user.Email == login.Email
                       && user.Password == login.Password
                       select user).SingleOrDefaultAsync();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                bool ValidEmail =
                    await (from UserAccount in _context.UserAccounts
                           where UserAccount.Email != null
                           select UserAccount).AnyAsync();
                
                bool InvalidPassword = await
                        (from UserAccount in _context.UserAccounts
                         where UserAccount.Password != login.Password
                         && account != null
                         select UserAccount).AnyAsync();


                if (account == null)
                {
                    // Credentials didn't match
                    ModelState.AddModelError(string.Empty, "Account not found.");
                    return View(login);
                }
                // log user in
                HttpContext.Session.SetInt32("UserId", account.UserAccountId);
                LogUserIn(account.UserAccountId);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            return View();
        }

        private void LogUserIn(int accountId)
        {
            HttpContext.Session.SetInt32("UserId", accountId);
        }
    }
}
