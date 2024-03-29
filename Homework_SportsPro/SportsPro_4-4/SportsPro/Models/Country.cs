﻿using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Country
    {
        [Required]
        public string CountryID { get; set; } 

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
