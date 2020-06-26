using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pets.Models;
using Pets.Repository;
using Pets.ViewModels;

namespace Pets.Controllers
{
  [Authorize]
  public class PetsController : Controller
  {
    private readonly IPetRepository _petRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public PetsController(UserManager<IdentityUser> userManager, IPetRepository petRepository)
    {
      _petRepository = petRepository;
      _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(CreateViewModel createViewModel)
    {
      Pet pet = new Pet();
      pet.Id = Guid.NewGuid();
      pet.AccountId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      pet.Name = createViewModel.Name;
      pet.AnimalType = createViewModel.Animal;
      _petRepository.AddPet(pet);

      return RedirectToAction("Index", "Home");
    }

  }
}
