using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pets.Models;

namespace Pets.Controllers
{
  public class HomeController : Controller
  {

    private readonly ILogger<HomeController> _logger;

    private UserManager<SignInModel> _userManager = new UserManager<SignInModel>();

    private SignInManager<SignInModel> _signInManager;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    [Route("signin")]
    public async Task<IActionResult> SignIn(SignInModel model)
    {
      var result = await _userManager.CreateAsync(model, model.Password);

      /*
      var result2 = await _signInManager.PasswordSignInAsync(Input.Email,
                   Input.Password, Input.RememberMe, lockoutOnFailure: true);
                   */


      Console.WriteLine(model.Username);

      if (model.Password == "admin")
      {
        return View("~/Views/Home/SignIn.cshtml");
      } else
      {
        return View("~/Views/Home/Index.cshtml");
      }
    }
  }
}
