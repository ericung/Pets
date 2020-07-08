using Pets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Repository
{
  public class SQLFoodRepository : IFoodRepository
  {
    private readonly ApplicationDbContext context;

    public SQLFoodRepository(ApplicationDbContext context)
    {
      this.context = context;
    }
  }
}
