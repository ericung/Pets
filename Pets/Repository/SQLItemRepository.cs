using Pets.Data;
using Pets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Repository
{
  public class SQLItemRepository : IItemRepository
  {
    private readonly ApplicationDbContext context;

    public SQLItemRepository(ApplicationDbContext context)
    {
      this.context = context;
    }

    public IEnumerable<Item> GetInventory(string userId)
    {
      IEnumerable<Item> inventory = context.Items.Where(element => element.AccountId == userId);
      return inventory;
    }

    public Item Create(Item item)
    {
      context.Items.Add(item);
      context.SaveChanges();
      return item;
    }
  }
}
