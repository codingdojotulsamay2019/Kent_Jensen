using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        public string firstName {get;set;}
        public string lastName {get;set;}
        public DateTime DoB {get;set;}
        public List<Dish> CreatedDishes {get;set;}
    }
}


