using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            TossMultipleCoins(10);
            Names();
            // Random Array
            // Create a function called RandomArray() that returns an integer array
            // Place 10 random integer values between 5-25 into the array
            // Print the min and max values of the array
            // Print the sum of all the values
        }
        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] nums = new int[10];
            for(int i = 0; i < nums.Length; i++)
            {
                int gen = rand.Next(5,25);
                nums[i] = gen;
                System.Console.WriteLine(gen);  
            }
            int Max = nums[0];
            int Min = nums[0];
            int Sum = 0;
            for(int i = 1; i < nums.Length; i++)
            {
                if(nums[i]> Max)
                {
                    Max = nums[i];
                }
                if(nums[i]< Min)
                {
                    Min = nums[i];
                }
                Sum += nums[i];
            }
            System.Console.WriteLine($"The minimum is {Min}. The maximum is {Max}. The sum is {Sum}.");
            return nums;
        }
        // Coin Flip
        // Create a function called TossCoin() that returns a string
        public static string TossCoin()
        {   
            string coinval ="";
            Console.WriteLine("Tossing a Coin!");
            Random randCoin = new Random();
            int coin = randCoin.Next(1,3);
            if(coin == 1)
                {
                    coinval = "Heads";
                }
            if(coin == 2)
                {
                    coinval = "Tails";
                }
            Console.WriteLine(coinval);
            return coinval;
        }
            // Have the function print "Tossing a Coin!"
            // Randomize a coin toss with a result signaling either side of the coin 
            // Have the function print either "Heads" or "Tails"
            // Finally, return the result

        // Create another function called TossMultipleCoins(int num) that returns a Double
            // Have the function call the tossCoin function multiple times based on num value
            // Have the function return a Double that reflects the ratio of head toss to total toss
        public static double TossMultipleCoins(int num)
        {   
            Double ratmax = num;
            Double count = 0;
            while(num > 0)
            {
                string Toss = TossCoin();
                num--;
                if(Toss=="Heads")
                {
                    count++;
                }
            }
            Double ratio = (count/ratmax);
            Console.WriteLine(ratio);
            return ratio;
        }

        public static List<string> Names()
        {
            List<string> names = new List<string>() {"Todd","Tiffany","Charlie","Geneva","Syndey"};
            Random rand = new Random();
            for(int i = names.Count; i >= 0; i--)
            {
                int x = rand.Next(0, i);
                names.Add(names[x]);
                names.Remove(names[x]);
            }
            System.Console.WriteLine(names);
            for(int j = 0; j < names.Count; j++)
            {
                if(names[j].Length < 6)
                {
                    names.Remove(names[j]);
                }
            }
            return names;
        }
    }
