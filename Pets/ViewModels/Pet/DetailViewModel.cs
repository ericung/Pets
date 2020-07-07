﻿using Pets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.ViewModels
{
  public class DetailViewModel : CreateViewModel
  {
    public Guid Id { get; set; }

    public int CurrentHunger { get; set; }

    public int MaxHunger { get; set; }
  }
}
