using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}

        [Required(ErrorMessage="Chef must have a first name!")]
        [Display(Name="First Name:")]
        public string firstName {get;set;}

        [Required(ErrorMessage="Chef must have a last name!")]
        [Display(Name="Last Name:")]
        public string lastName {get;set;}
        
        [Required(ErrorMessage="Chef must have a birthday!")]
        [Display(Name="Birthday:")]
        public DateTime DoB {get;set;}
        
        public int CalculateAge()
        {
            int age = 0;
            int yearOfBirth = this.DoB.Year;
            age = DateTime.Now.Year - yearOfBirth;
            if (DateTime.Now.DayOfYear < this.DoB.DayOfYear)
                age = age-1;
                return age;
        }
        public List<Dish> CreatedDishes {get;set;}
    }
}


