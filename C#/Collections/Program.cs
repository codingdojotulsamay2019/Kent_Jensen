using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Three Basic Arrays
            // Create an array to hold integer values 0 through 9
            int[] ZeroToNine = new int[10] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] Names = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] TrueFalse = new bool[10] {true,false,true,false,true,false,true,false,true,false};
            // List of Flavors
            // Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            List<string> flavors = new List<string>();
            flavors.Add("chocolate");
            flavors.Add("vanilla");
            flavors.Add("strawberry");
            flavors.Add("neopolitan");
            flavors.Add("pistachio");
            // Output the length of this list after building it
            Console.WriteLine(flavors.Count);
            // int count = 0;
            // foreach (str Flavor in FlavorTypes)
            //     {
            //     count ++;
            //     }
            // Console.WriteLine(count);
            // Output the third flavor in the list, then remove this value
    
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);

            // Output the new length of the list (It should just be one fewer!)
            Console.WriteLine(flavors.Count);
            // User Info Dictionary
            // Create a dictionary that will store both string keys as well as string values
            Dictionary<String,String> nameDict = new Dictionary<String,String>();
            Random rand = new Random();
            for(int i = 0; i <Names.Length;i++)
            {
                nameDict.Add(Names[i], flavors[rand.Next(0,5)]);
            }
            // Loop through the dictionary and print out each user's name and their associated ice cream flavor
            foreach(KeyValuePair<string,string> j in nameDict)
            {
                Console.WriteLine(j.Key + " - " + j.Value);
            }
        }
    }       

}
