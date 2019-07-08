using System;
using System.Collections.Generic;

namespace WizardNinjaSamurai
{
    class Wizard : Human
        {
            public override Wizard()
            {
                int health = 50;
                int intel = 25;
                
                public int Attack(Human target)
                {
                    int dmg = (5*intel);
                    target.health -= dmg;
                    health += dmg;
                    Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");

                }
                public int Heal(Human target)
                {
                    target.Health += (10 * intel);
                }
            }
        }
        //Wizard should have a default health of 50 and Intelligence of 25 
        //Provide an override Attack method to Wizard, which reduces the target by 5 * Intelligence and heals the Wizard by the amount of damgage dealt
        //Wizard should have a method called Heal, which when invoked, heals a target Human by 10 * Intelligence
}
