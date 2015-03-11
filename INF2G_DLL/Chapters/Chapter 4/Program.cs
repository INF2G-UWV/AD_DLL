using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_4
{
    internal class Program
    {
        public static void Run(string[] args)
        {
            //Create an array and fill it
            string[] chars = new string[] {"z","x", "g", "r"};

            //Create a generic MinMax search
            MinMax<string> stringTest = new MinMax<string>(chars, chars);

            //Output minimum 
            Console.WriteLine(stringTest.FindMinimum());
            Console.WriteLine();

            //Output maximum 
            Console.WriteLine(stringTest.FindMaximum());
            Console.ReadLine();
        }

        
    }
}
