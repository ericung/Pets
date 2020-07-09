using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Models
{
  public class Item
  {
    public Guid Id { get; set; }

    public String AccountId { get; set; }

    public String Name { get; set; }

    public ItemType Type { get; set; }

    public int Value { get; set; }
  }
}
