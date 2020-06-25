using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pets.Data;
using Pets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Repository
{
  public class SQLPetRepository : IPetRepository
  {
    private readonly ApplicationDbContext context;

    public SQLPetRepository (ApplicationDbContext context)
    {
      this.context = context;
    }

    public Pet AddPet(Pet pet)
    {
      context.Pets.Add(pet);
      context.SaveChanges();
      return pet;
    }

    public IEnumerable<Pet> GetPetsByUserId(string userId)
    {
      return context.Pets.Where(element => element.AccountId == userId);
    }
  }
}
