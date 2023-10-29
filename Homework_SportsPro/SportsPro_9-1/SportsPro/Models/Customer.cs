﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SportsPro.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }



      

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Postal Code")]
        public string CountryID { get; set; } = string.Empty;

        [ValidateNever]
        public Country? Country { get; set; }

        public string Phone { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;



        public string FullName => FirstName + " " + LastName;   // read-only property

    }
}