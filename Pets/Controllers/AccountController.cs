using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers
{
  public class AccountController : Controller
  {
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly UserManager<IdentityUser> userManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
      this.userManager = userManager;
      this.signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult SignIn()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
        
        if (result.Succeeded)
        {
          return RedirectToAction("index", "home");
        }

        ModelState.AddModelError(string.Empty, "Invalid Sign In Attempt");
      }

      return View(model);
    }
  }
}
