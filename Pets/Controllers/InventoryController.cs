using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pets.Models;
using Pets.Repository;
using Pets.ViewModels;

namespace Pets.Controllers
{
  public class InventoryController : Controller
  {

    SignInManager<IdentityUser> _signInManager;
    IItemRepository _itemRepository;
    
    public InventoryController(SignInManager<IdentityUser> signInManager, IItemRepository itemRepository)
    {
      _signInManager = signInManager;
      _itemRepository = itemRepository;
    }

    public IActionResult Index()
    {
      InventoryViewModel inventoryViewModel = new InventoryViewModel();

      return View(inventoryViewModel);
    }
  }
}
