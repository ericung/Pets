using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pets.Models;
using Pets.ViewModels;
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
    public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
    {
      if (ModelState.IsValid)
      {
        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

        if (result.Succeeded)
        {
          if (!string.IsNullOrEmpty(returnUrl))
          {
            return LocalRedirect(returnUrl);
          }
          else
          {
            return RedirectToAction("index", "home");
          }
        }

        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
      }

      return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> SignOut()
    {
      await signInManager.SignOutAsync();
      return RedirectToAction("index", "home");
    }

    [HttpGet]
    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
      if (ModelState.IsValid)
      {
        // Copy data from RegisterViewModel to IdentityUser
        var user = new IdentityUser
        {
          UserName = model.Email,
          Email = model.Email
        };

        // Store user data in AspNetUsers database table
        var result = await userManager.CreateAsync(user, model.Password);

        // If user is successfully created, sign-in the user using
        // SignInManager and redirect to index action of HomeController
        if (result.Succeeded)
        {
          await signInManager.SignInAsync(user, isPersistent: false);
          return RedirectToAction("index", "home");
        }

        // If there are any errors, add them to the ModelState object
        // which will be displayed by the validation summary tag helper
        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }

      return View(model);
    }
  }
}
