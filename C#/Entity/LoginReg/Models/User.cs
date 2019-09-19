using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginReg.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage="First name is required!")]
        [MinLength(2, ErrorMessage="First name must be 2 characters or longer!")]
        [Display(Name="First Name:")]
        public string FirstName {get;set;}

        [Required(ErrorMessage="Last name is required!")]
        [MinLength(2, ErrorMessage="Last name must be 2 characters or longer!")]
        [Display(Name="Last Name:")]
        public string LastName {get;set;}


        [EmailAddress]
        [Required(ErrorMessage="Email is required!")]
        [Display(Name="Email:")]
        public string Email {get;set;}


        [DataType(DataType.Password)]
        [Required(ErrorMessage="Password is required!")]
        [Display(Name="Password:")]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string Password {get;set;}


        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;


        // Will not be mapped to your users table!
        [NotMapped]
        [Required(ErrorMessage="Confirm password cannot be blank!")]
        [Compare("Password", ErrorMessage="Passwords must match!")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password:")]
        public string Confirm {get;set;}
    }
}