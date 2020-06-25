using Pets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Repository
{
  public interface IPetRepository
  {
    IEnumerable<Pet> GetPetsByUserId(string userId);

    Pet AddPet(Pet pet);
  }
}
