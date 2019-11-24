using System.ComponentModel.DataAnnotations;
namespace LoginRegNew.Models
{

    public class LoginUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email: ")]
        public string loginuseremail {get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string loginuserpass {get;set;}
    }
}