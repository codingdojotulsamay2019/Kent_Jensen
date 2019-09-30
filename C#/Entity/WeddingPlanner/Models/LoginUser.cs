using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class LoginUser
    {

        [Required]
        [Display(Name = "Email")]
        public string LoginEmail {get; set;}
        [Required]
        [Display(Name = "Password")]
        public string LoginPassword { get; set; }
    }
}