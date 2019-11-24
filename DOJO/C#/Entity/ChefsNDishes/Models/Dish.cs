using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int DishId { get; set; }
        
        // MySQL VARCHAR and TEXT types can be represented by a string
        [Required(ErrorMessage="Dish must have a name!")]
        [Display(Name="Dish Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage="Dish must have a Chef!")]
        [Display(Name="Chef Name:")]
        public int ChefId { get; set; }

        [Required(ErrorMessage="Dish must have a rating!")]
        [Range(0,6)]
        [Display(Name="Tastiness:")]
        public int? Tastiness { get; set; }

        [Required(ErrorMessage="Dish must have a calorie value!")]
        [Display(Name="Calorie value:")]
        [Range(1,50000,ErrorMessage="Calorie value must be greater than 0, or less than 50000.")]

        public int? Calories { get; set; }
        
        [Required(ErrorMessage="Dish must have a description!")]
        [Display(Name="Description:")]
        public string Description { get; set; }

        [Required(ErrorMessage="Dish must have a chef!")]
        [Display(Name="Chef:")]
        public Chef Creator {get;set;}

        // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        //constructor function named the same as class itself to handle auto-update of date&time.
        public Dish()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}