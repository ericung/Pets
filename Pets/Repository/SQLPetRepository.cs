using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pets.Controllers;
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
      switch(pet.AnimalType)
      {
        case Animal.Cat: pet.MaxHunger = 9; break;
        case Animal.Dog: pet.MaxHunger = 13; break;
        case Animal.Fish: pet.MaxHunger = 5; break;
      }
      pet.CurrentHunger = pet.MaxHunger;
      pet.LastAte = DateTime.Now;

      context.Pets.Add(pet);
      context.SaveChanges();
      return pet;
    }

    public IEnumerable<Pet> GetPetsByUserId(string userId)
    {
      IEnumerable<Pet> pets = context.Pets.Where(element => element.AccountId == userId);
      return pets;
    }

    public Pet GetPetById(Guid id)
    {
      IEnumerable<Pet> pets = context.Pets.Where(element => element.Id.Equals(id));
      return pets.FirstOrDefault();
    }

    public Pet RemovePet(string id)
    {
      Pet pet = context.Pets.Find(id);
      if (pet != null)
      {
        context.Pets.Remove(pet);
        context.SaveChanges();
      }

      return pet;
    }

    public Pet UpdatePet(Pet petChanges)
    {
      switch(petChanges.AnimalType)
      {
        case Animal.Cat: petChanges.MaxHunger = 9; break;
        case Animal.Dog: petChanges.MaxHunger = 13; break;
        case Animal.Fish: petChanges.MaxHunger = 5; break;
      }
      petChanges.CurrentHunger = petChanges.MaxHunger;
      petChanges.LastAte = DateTime.Now;

      var pet = context.Pets.Attach(petChanges);
      pet.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      context.SaveChanges();
      return petChanges;
    }

    public void UpdateHunger(String userId)
    {
      IEnumerable<Pet> pets = context.Pets.Where(element => element.AccountId == userId);

      foreach (Pet petHunger in pets)
      {
        TimeSpan difference = DateTime.Now.Subtract(petHunger.LastAte);
        int hunger = petHunger.CurrentHunger - difference.Days;

        if (hunger < 0 )
        {
          petHunger.CurrentHunger = 0;
        }
        else
        {
          petHunger.CurrentHunger = hunger;
        }

        var pet = context.Pets.Attach(petHunger);
        pet.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      }

      context.SaveChanges();
    }

    public Pet FeedPet(Guid id, int food)
    {
      IEnumerable<Pet> pets = context.Pets.Where(element => element.Id.Equals(id));
      Pet pet = pets.FirstOrDefault();
      int hunger = pet.CurrentHunger + food;

      if (hunger > pet.MaxHunger)
      {
        hunger = pet.MaxHunger;
      }

      pet.CurrentHunger = hunger;
      return pet;
    }
  }
}
