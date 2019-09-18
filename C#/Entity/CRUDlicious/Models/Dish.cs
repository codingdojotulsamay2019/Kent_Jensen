using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Crudlicious.Models
{
    public class Dish
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int ID { get; set; }
        // MySQL VARCHAR and TEXT types can be represented by a string
        [Required(ErrorMessage="Dish must have a name!")]
        [Display(Name="Dish Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage="Dish must have a Chef!")]
        [Display(Name="Chef Name:")]
        public string Chef { get; set; }

        [Required(ErrorMessage="Dish must have a rating!")]
        [Range(0,6)]
        [Display(Name="Tastiness:")]
        public int Tastiness { get; set; }

        [Required(ErrorMessage="Dish must have a calorie value!")]
        [Display(Name="Calorie value:")]
        [Range(1,50000,ErrorMessage="Calorie value must be greater than 0.")]

        public int Calories { get; set; }
        
        [Required(ErrorMessage="Dish must have a description!")]
        [Display(Name="Description:")]
        public string Description { get; set; }

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