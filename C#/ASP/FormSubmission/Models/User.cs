using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models

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
        [Range(0,100)]
        [Display(Name = "Age: ")]
        public int? userage {get;set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email: ")]
        public string useremail {get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string userpass {get;set;}
    }
}