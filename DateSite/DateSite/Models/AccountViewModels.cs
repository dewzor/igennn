﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DateSite.Models
{

    public class RegisterModel
    {
        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "You need to enter a first name")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "You need to enter a last name")]
        public string Lastname { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "You need to enter an e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "You need to enter a username")]
        [MinLength(4, ErrorMessage = "Your username need to consist of atleast 4 characters")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter a password")]
        [MinLength(6, ErrorMessage = "Your password need to consist of atleast 6 characters")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string PasswordMatch { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Age")]
        public string Age { get; set; }

        [Display(Name = "About")]
        public string About { get; set; }

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

    }

    public class SecurityModel
    {
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public bool VISIBILITY { get; set; }

        public int PID { get; set; }

        [ForeignKey("PID")]
        public virtual RegisterModel Users { get; set; }
    }


    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class MyAccountModel
    {
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter a password")]
        [MinLength(6, ErrorMessage = "Your password need to consist of atleast 6 characters")]
        public string PASSWORD { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("PASSWORD", ErrorMessage = "Password mismatch")]
        public string PASSWORDMATCH { get; set; }

        [Display(Name = "Current Password")]
        [Required(ErrorMessage = "Enter current password")]
        [MinLength(6, ErrorMessage = "Your password need to consist of atleast 6 characters")]
        public string OLDPASSWORD { get; set; }
    }

}
