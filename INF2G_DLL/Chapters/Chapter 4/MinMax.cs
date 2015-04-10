using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_4
{
    /// <summary>
    ///     MinMax Test.
    ///     Author: Xing Woo - INF2G
    /// </summary>
    internal class MinMax
    {
        /// <summary>
        ///     Main execution.
        /// </summary>
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("****MinMax Test****");
            Console.WriteLine("*******************");

            //Create an array and fill it
            string[] chars = {"z", "x", "g", "r"};

            //Print array
            Console.WriteLine("\nArray contents:");
            foreach (var t in chars)
            {
                Console.WriteLine(t);
            }

            //Create a generic MinMax search
            var stringTest = new MinMax<string>(chars, chars);

            //Output minimum 
            Console.WriteLine("\nMinimum:");
            Console.WriteLine(stringTest.FindMinimum());
            Console.WriteLine();

            //Output maximum 
            Console.WriteLine("\nMaximum:");
            Console.WriteLine(stringTest.FindMaximum());
            Console.WriteLine("\nPress a key to continue");
            Console.ReadKey(true);
        }
    }
}