﻿using System;
using System.ComponentModel.DataAnnotations;

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
