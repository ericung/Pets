﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Models
{
  public class SignInViewModel
  {
    [Required]
    [EmailAddress]
    public String Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public String Password { get; set; }
  }
}
