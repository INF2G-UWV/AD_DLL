using System;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_4
{
    internal class MinMax
    {
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