using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pets.Models;
using Pets.Repository;
using Pets.ViewModels;

namespace Pets.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {

    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<HomeController> _logger;
    private readonly IPetRepository petRepository;
    // private UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>();




    public HomeController(SignInManager<IdentityUser> signInManager, ILogger<HomeController> logger, IPetRepository petRepository)
    {
      _signInManager = signInManager;
      _logger = logger;
      this.petRepository = petRepository;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
      IndexViewModel indexViewModel = new IndexViewModel();

      if (_signInManager.IsSignedIn(User))
      {
        String userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        indexViewModel.Pets = petRepository.GetPetsByUserId(userId).ToList();
      }

      return View(indexViewModel);
    }

    [AllowAnonymous]
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
