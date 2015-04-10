using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_3
{
    /// <summary>
    ///     Sorting algorithms testing class.
    ///     Author: Ferdi Smit - INF2G
    /// </summary>
    internal class Sort
    {
        private static string strings;
        private static string emptyString;
        private static string[] stringArray;
        private static string[] sortedArray;
        private static Random random;
        private static Sorting<string> sort;

        /// <summary>
        ///     Main execution.
        /// </summary>
        public static void Run()
        {
            BuildData();
            SortingProgram();
        }

        private static void BuildData()
        {
            // String with letters and numbers
            strings = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

            // empty string
            emptyString = "";

            // Original array with string
            stringArray = new string[10];

            // Array where the original array is being copied to
            sortedArray = new string[10];

            // Random generator to create random strings
            random = new Random(100);

            // Sorting class will be used to sort the arrays
            sort = new Sorting<string>(stringArray);

            // A double loop to generate 10 random  strings
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j <= 8; j++)
                {
                    emptyString += strings[random.Next(strings.Length)];
                }
                stringArray.SetValue(emptyString, i);
                emptyString = "";
            }
        }

        /// <summary>
        ///     Main sorting program.
        /// </summary>
        private static void SortingProgram()
        {
            //Check if active
            var running = true;

            // Copy of the original array
            stringArray.CopyTo(sortedArray, 0);
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("****Sorting Test****");
            Console.WriteLine("********************");
            Console.WriteLine("(1) Print a unsorted list.");
            Console.WriteLine("(2) Print a list sorted with the BubbleSort algorithm.");
            Console.WriteLine("(3) Print a list sorted with the SmartBubbleSort algorithm.");
            Console.WriteLine("(4) Print a list sorted with the InsertionSort algorithm.");
            Console.WriteLine("(X) Exit program");


            // Reading input
            var input = Console.ReadKey(true);

            // Switch to perform several different actions
            switch (input.Key)
            {
                // Printing the original array
                case ConsoleKey.D1:
                    Console.WriteLine("\nAn unsorted list\n");
                    foreach (var singleString in stringArray)
                    {
                        Console.WriteLine(singleString);
                    }
                    Console.WriteLine("\nPress a key to continue");
                    Console.ReadKey(true);
                    break;

                // Sorting the original array with BubbleSort()
                case ConsoleKey.D2:
                    Console.WriteLine("\nList sorted by the BubbleSort algorithm\n");
                    sort.BubbleSort(sortedArray);
                    foreach (var singleString in sortedArray)
                    {
                        Console.WriteLine(singleString);
                    }
                    Console.WriteLine("\nPress a key to continue");
                    Console.ReadKey(true);
                    break;

                // Sorting copied array with BubbleSort()
                case ConsoleKey.D3:
                    Console.WriteLine("\nList sorted by the SmartBubbleSort algorithm\n");
                    sort.SmartBubbleSort(sortedArray);
                    foreach (var singleString in sortedArray)
                    {
                        Console.WriteLine(singleString);
                    }
                    Console.WriteLine("\nPress a key to continue");
                    Console.ReadKey(true);
                    break;

                // Sorting copied array with InsertionSort()
                case ConsoleKey.D4:
                    Console.WriteLine("\nList sorted by the InsertionSort algorithm\n");
                    sort.InsertionSort(sortedArray);
                    foreach (var singleString in sortedArray)
                    {
                        Console.WriteLine(singleString);
                    }
                    Console.WriteLine("\nPress a key to continue");
                    Console.ReadKey(true);
                    break;

                // Exiting the program
                case ConsoleKey.X:
                    running = false;
                    break;
                case ConsoleKey.Backspace:
                    running = false;
                    break;
            }
            if (running)
            {
                SortingProgram();
            }
        }
    }
}