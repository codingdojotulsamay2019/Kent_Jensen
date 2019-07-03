using System;
using System.Collections.Generic;

namespace Human
{
    class Human
        {
            // Fields for Human
            public string Name;
            public int Strength;
            public int Intelligence;
            public int Dexterity;
            private int health;
            // add a public "getter" property to access health
            public int Health
            {
                get { return health; }
                set { health = value; }
            }
            // Add a constructor that takes a value to set Name, and set the remaining fields to default values (stats = 3, health = 100)
            public Human(string name)
            {
                Name = name;
                Strength = 3;
                Intelligence = 3;
                Dexterity = 3;
                health = 100;
            }
            // Add a constructor to assign custom values to all fields
            public Human(string name, int strength, int intelligence, int dexterity, int hp)
            {
                Name = name;
                Strength = strength;
                Intelligence = intelligence;
                Dexterity = dexterity;
                Health = hp;
            }
            // Build Attack method
            public int Attack(Human target)
            {
                System.Console.WriteLine($"Attacking {target}!");
                int damage = Strength*5;
                target.Health -= damage;
                return target.Health;
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
            Human Person1 = new Human("Kent", 8, 15, 12, 125);
            Human Person2 = new Human("Target Dummy", 3, 3, 3, 100);
            Person1.Attack(Person2);
            System.Console.WriteLine(Person1.Name);
            System.Console.WriteLine(Person1.Strength);
            System.Console.WriteLine(Person1.Intelligence);
            System.Console.WriteLine(Person1.Dexterity);
            System.Console.WriteLine(Person1.Health);
            System.Console.WriteLine(Person2.Name);
            System.Console.WriteLine(Person2.Health);
        }
    }
}