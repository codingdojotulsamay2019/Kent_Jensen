using System;
using System.Collections.Generic;
namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet Shoneys = new Buffet();
            Ninja Jimbob = new Ninja();
            while(Jimbob.IsFull == false)
            {
                Jimbob.Eat(Shoneys.Serve());
            }
        }
        class Food
        {
            public string Name;
            public int Calories;
            // Foods can be Spicy and/or Sweet
            public bool IsSpicy; 
            public bool IsSweet; 
            // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
            public Food(string name, int cal, bool spicy, bool sweet)
            {
                Name = name;
                Calories = cal;
                IsSpicy = spicy;
                IsSweet = sweet;
            }
        }
        class Buffet
        {
            public List<Food> Menu;
            
            //constructor sets Menu to hard coded list of 7 or more Food objects you instantiate manually.
            public Buffet()
            {
                Menu = new List<Food>()
                {
                    new Food("Curry", 550, true, false),
                    new Food("Banana", 150, false, true),
                    new Food("Chicken Soup", 400, false, false),
                    new Food("Hamburger", 800, false, false),
                    new Food("Burrito", 600, true, false),
                    new Food("Apple", 100, false, true),
                    new Food("Fries", 750, false, false)
                };
            }
        
            public Food Serve()
            //build out Serve to randomly select a Food object from Menu and returns that object.
            {
                Random rand = new Random();
                int generate = rand.Next(0,Menu.Count);
                Food target = Menu[generate];
                return target;
            }
        }
        class Ninja
        {
            private int calorieIntake;
            public List<Food> FoodHistory;
            // add a constructor that sets calorieIntake to 0 and creates a new empty list of Food objects to FoodHistory
            public Ninja()
            {
                calorieIntake = 0;
                FoodHistory = new List<Food>();
            }
            // add a public "getter" property called "IsFull" that returns boolean based on if calorieIntake is > 1200
            public bool IsFull
            {
                get
                {
                    if(calorieIntake > 1200)
                    {
                        System.Console.WriteLine("The ninja is full!");
                        return true;
                    }
                    else
                    {
                        System.Console.WriteLine("The ninja is still hungry!");
                        return false;
                    }
                }
            }
            // build out the Eat method so that if ninja is NOT full
                // adds calorie value to the ninja's total calorieIntake
                //adds the randomly selected Food object to ninja's FoodHistory list
                // writes the Food's Name - and if it is sweet/spicy to the console. 
            // if he IS full
                //issue warning to console that ninja is full and cannot eat any more.

            public void Eat(Food item)
            {
                System.Console.WriteLine($"The Ninja's calorie count is: {calorieIntake}");
                if(calorieIntake > 1200)
                {
                    System.Console.WriteLine("Ninja is stuffed. He can't even eat a wafer thin mint.");
                }
                else
                {
                    System.Console.WriteLine($"The ninja is still hungry. He's going to grab a {item.Name}");
                    FoodHistory.Add(item);
                    calorieIntake+= item.Calories;
                    System.Console.WriteLine($"The food had {item.Calories} calories.");
                }
            }
        }
        
    }
}



