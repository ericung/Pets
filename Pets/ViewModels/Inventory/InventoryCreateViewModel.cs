using Pets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.ViewModels.Inventory
{
  public class InventoryCreateViewModel
  {
    public Item item { get; set; }

    public String Name { get; set; }

    public ItemType Type { get; set; }

    public int Value { get; set; }
  }
}
