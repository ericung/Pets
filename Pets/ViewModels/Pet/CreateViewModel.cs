using Pets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.ViewModels
{
  public class CreateViewModel
  {
    [Required]
    public String Name { get; set; }

    [Required]
    public Animal Animal { get; set; }
  }
}
