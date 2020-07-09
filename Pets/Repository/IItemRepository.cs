using Pets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Repository
{
  public interface IItemRepository
  {
    IEnumerable<Item> GetInventory(string userId);
  }
}
