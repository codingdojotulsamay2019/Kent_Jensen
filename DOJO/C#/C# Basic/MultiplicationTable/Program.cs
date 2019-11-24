using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // With the values 1-10, use code to generate a multiplication table like the one below.

            // Multidimensional array declaration
            int [,] array2D = new int[10,10] {
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
            for(int i=1; i<10; i++) {
                for(int j=0; j<10;j++){
                    array2D[i,j] = array2D[0,j]*(i+1);
                    }
                    Console.WriteLine("Value in array2D[{0},{1}] = {2}", i, j, array2D[i+1,j]);
                }
            }
            // This is equivalent to:
            //  int [,] array2D = new int[3,2]  {  { 0,0 }, { 0,0 }, { 0,0 } }; 
            // This e0ample has 2 large rows that each contain 3 arrays -- and each of those arrays is length 4.
            
            // Directly accessing a multidimensional array

        }
    }
}
