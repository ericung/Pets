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
using Pets.ViewModels.Inventory;

namespace Pets.Controllers
{
  [Authorize]
  public class InventoryController : Controller
  {

    SignInManager<IdentityUser> _signInManager;
    IItemRepository _itemRepository;
    
    public InventoryController(SignInManager<IdentityUser> signInManager, IItemRepository itemRepository)
    {
      _signInManager = signInManager;
      _itemRepository = itemRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
      InventoryViewModel inventoryViewModel = new InventoryViewModel();
      String userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var list = _itemRepository.GetInventory(userId);
      inventoryViewModel.Inventory = new List<Item>();

      foreach (Item item in list)
      {
        inventoryViewModel.Inventory.Add(item);
      }

      return View(inventoryViewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(InventoryCreateViewModel inventoryCreateViewModel)
    {
      Item item = new Item();
      item.Id = Guid.NewGuid();
      item.AccountId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      item.Name = "Food";
      item.Type = ItemType.Food;
      item.Value = 6;
      _itemRepository.Create(item);

      return RedirectToAction("Index", "Inventory");
    }
  }
}
