using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Models
{
  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    public String Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public String Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public String RetypePassword { get; set; }
  }
}
