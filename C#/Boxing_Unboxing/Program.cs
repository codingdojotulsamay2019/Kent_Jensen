using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> BoxedData = new List<object>();
            BoxedData.Add(7);
            BoxedData.Add(28);
            BoxedData.Add(-1);
            BoxedData.Add(true);
            BoxedData.Add("chair");
            // Create an empty List of type object 
            // Add the following values to the list: 7, 28, -1, true, "chair" 
            // Loop through the list and print all values (Hint: Type Inference might help here!) 
            int sum = 0;
            for(int i = 0; i<BoxedData.Count;i++)
            {
                if(BoxedData[i] is int)
                {
                    Console.WriteLine((int)BoxedData[i]);
                    sum += (int)BoxedData[i];
                }
                if(BoxedData[i] is string)
                {
                    Console.WriteLine((string)BoxedData[i]);
                }
                if(BoxedData[i] is Boolean) 
                {
                    Console.WriteLine((Boolean)BoxedData[i]);
                }
            }
            // Add all values that are Int type together and output the sum
            Console.WriteLine(sum);
        }
    }
}
