using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Models
{
  public class Pet
  {
    public Guid Id { get; set; }

    [Required]
    public String AccountId { get; set; }

    [Required]
    public Animal AnimalType { get; set; }

    [Required]
    public String Name { get; set; }
  }
}
