using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pets.Models;
using Pets.Repository;
using Pets.ViewModels;
using System;
using System.Security.Claims;

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

    [HttpGet]
    public IActionResult Update(Guid id)
    {
      Pet pet = _petRepository.GetPetById(id);
      UpdateViewModel updateViewModel = new UpdateViewModel();
      updateViewModel.Name = pet.Name;
      updateViewModel.Animal = pet.AnimalType;
      
      return View(updateViewModel);
    }

    [HttpPost]
    public IActionResult Update(UpdateViewModel updateViewModel)
    {
      Pet pet = _petRepository.GetPetById(updateViewModel.Id);
      pet.Name = updateViewModel.Name;
      pet.AnimalType = updateViewModel.Animal;
      _petRepository.UpdatePet(pet);
      return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Detail(Guid id)
    {
      Pet pet = _petRepository.GetPetById(id);
      DetailViewModel detailViewModel = new DetailViewModel();
      detailViewModel.Name = pet.Name;
      detailViewModel.Animal = pet.AnimalType;

      return View(detailViewModel);
    }
  }
}
