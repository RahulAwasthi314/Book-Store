﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
