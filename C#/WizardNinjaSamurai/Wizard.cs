using System;
using System.Collections.Generic;

namespace WizardNinjaSamurai
{
    class Wizard : Human
        {
            public Wizard(string Name) : base(Name)
            {
                Health = 50;
                Intelligence = 25;
            }
            public Wizard(string name, int str, int intel, int dex, int hp) : base(name, str, intel, dex, hp)
            {
            }
            public override int Attack(Human target)
            {
                int dmg = (5*Intelligence);
                target.Health -= dmg;
                health += dmg;
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
                return target.Health;
            }
            public void Heal(Human target)
            {
                target.Health += (10 * Intelligence);
            }
        }
        //Wizard should have a default health of 50 and Intelligence of 25 
        //Provide an override Attack method to Wizard, which reduces the target by 5 * Intelligence and heals the Wizard by the amount of damgage dealt
        //Wizard should have a method called Heal, which when invoked, heals a target Human by 10 * Intelligence
}
