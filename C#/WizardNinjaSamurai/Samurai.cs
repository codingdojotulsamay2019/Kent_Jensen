using System;
using System.Collections.Generic;

namespace WizardNinjaSamurai
{
    class Samurai : Human
    {
        public Samurai(string Name) : base(Name)
        {
            Health = 200;
        }
        public Samurai(string name, int str, int intel, int dex, int hp) : base(name, str, intel, dex, hp)
        {
        }
        public override int Attack(Human target)
        {
            target.Health = base.Attack(target);
            if(target.Health <50)
            {
                target.Health = 0;
                System.Console.WriteLine($"{Name} killed {target.Name} with a swift execution.");
            }
            return target.Health;
        }
        public void Steal(Human target)
        {
            target.Health -= 5;
            Health += 5;
        }
        //Samurai should have a default health of 200
        //Provide an override Attack method to Samurai, which calls the base Attack and reduces the target to 0 if it has less than 50 remaining health points.
        //Samurai should have a method called Meditate, which when invoked, heals the Samurai back to full health.
    }
}