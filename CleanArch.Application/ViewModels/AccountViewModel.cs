﻿using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }

    public enum CheckUser
    {
        UsrNameAndEmailNotValid,
        UserNameNotValid,
        EmailNotValid,
        Ok
    }
}