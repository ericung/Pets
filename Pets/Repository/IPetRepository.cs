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

    Pet GetPetById(Guid petId);

    Pet AddPet(Pet pet);

    Pet UpdatePet(Pet petChanges);

    void UpdateHunger(String userId);

    Pet RemovePet(String id);

    Pet FeedPet(Guid id, int food);
  }
}
