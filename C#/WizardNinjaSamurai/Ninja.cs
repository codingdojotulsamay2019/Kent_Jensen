using System;
using System.Collections.Generic;

namespace WizardNinjaSamurai
{
    class Ninja : Human
    {
        public Ninja(string Name) : base(Name)
        {
            Dexterity = 175;
        }
        public Ninja(string name, int str, int intel, int dex, int hp) : base(name, str, intel, dex, hp)
        {
        }
        public override int Attack(Human target)
        {
            int dmg = (Dexterity*5);
            target.Health -= dmg;
            Random rand = new Random();
            if(rand.Next(0,5) == 0)
            {
                target.Health -= 10;
                Console.WriteLine($"{Name} got 10 extra damage on {target.Name}!");

            }
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }
        public void Steal(Human target)
        {
            target.Health -= 5;
            Health += 5;
        }
        //Ninja should have a default dexterity of 175
        //Provide an override Attack method to Ninja, which reduces the target by 5*Dexterity and a 20% chance of dealing an additional 10 points of damage.
        //Ninja should have a method called Steal, reduces a target Human's health by 5 and adds this amount to its own health.
    }
}