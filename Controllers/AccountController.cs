using Microsoft.AspNetCore.Mvc;
using CarWashApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarWashApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
     public IActionResult Login()
        {
            return View("~/Views/CarWashServices/Login.cshtml");
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // For demonstration purposes, we're using a simple hardcoded check.
                // In a real application, you should validate the user against a database.
                if (model.Username == "admin" && model.Password == "password")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                   // Redirect to the home page
                     return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult LoginAndRedirect(Login model)
{
    // Handle login here...

    // Redirect to the home page
    return RedirectToAction("Index", "Home");
}

// GET: Account/Register
        public IActionResult Register()
        {
            return View("~/Views/CarWashServices/Register.cshtml");
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add your registration logic here
                // If registration is successful, redirect to the home page
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
