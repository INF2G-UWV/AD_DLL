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
        /// <param name="args"></param>
        public static void Run(string[] args)
        {
            //Create an array and fill it
            string[] chars = {"z", "x", "g", "r"};

            //Create a generic MinMax search
            var stringTest = new MinMax<string>(chars, chars);

            //Output minimum 
            Console.WriteLine(stringTest.FindMinimum());
            Console.WriteLine();

            //Output maximum 
            Console.WriteLine(stringTest.FindMaximum());
            Console.ReadLine();
        }
    }
}