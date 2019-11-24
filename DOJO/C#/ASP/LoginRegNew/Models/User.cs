using System.ComponentModel.DataAnnotations;
namespace LoginRegNew.Models
{

        public class User
        {
            [Required]
            [MinLength(4)]
            [Display(Name = "First Name: ")]
            public string fName {get;set;}

            [Required]
            [MinLength(4)]
            [Display(Name = "Last Name: ")]
            public string lName {get;set;}

            [Required]
            [EmailAddress]
            [Display(Name = "Email: ")]
            public string useremail {get;set;}

            [Required]
            [MinLength(8)]
            [DataType(DataType.Password)]
            [Display(Name = "Password: ")]
            public string userpass {get;set;}
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password: ")]
            [Compare("userpass", ErrorMessage="Password fields must match!")]
            public string userpassvalid {get;set;}
        }

}