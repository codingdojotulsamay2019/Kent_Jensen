using System;
using System.Collections.Generic;
namespace Fundamentals1
{
    class Program
    {
        static void Main(string[] args)
        {
            Print1To255();
            PrintDiv3or5();
        }
        static void Print1To255()
        {
            for (int i=1;i<=255;i++)
            {
                Console.WriteLine(i);
            }
        }
        static void PrintDiv3or5()
        {
            int i = 1;
            while (i <= 100)
            {
                if (i % 3 == 0 && i%5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                    i++;
                }
                else if (i % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                        i++;
                    }
                else if (i % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                        i++;
                    }
                else
                    {
                        i++;
                    }
            }

        }
    }
}
