﻿using System;
using System.Collections;
using DLL;

namespace DLL_Test.Chapters.Chapter_4
{
    /// <summary>
    ///     Binary Search Test.
    ///     Author: Selami Çetingüney - INF2G
    /// </summary>
    internal class BinarySearch
    {
        /// <summary>
        ///     Main Execution
        /// </summary>
        public static void Run()
        {
            Console.Clear();
            // Create a timer
            var timer = new HighResolutionTimer(true);

            // Create an array and fill it;
            string[] rndWords =
            {
                "Pizza", "Spaghetti", "Bread", "Chickingwings", "Cheese", "Salad", "Hallo"
                , "Test", "NogEenTest", "Auto", "Fiets", "Motor", "Vrachtwagen", "Laptop", "Desktop"
                , "Apple", "Android", "Windows", "Linux", "GPU", "CPU", "Mouse", "Screen"
            };

            // Create a Generic BinarySearch;
            var bsearch = new BinarySearch<string>();

            Console.WriteLine("***************************");
            Console.WriteLine("****Binary Search Test****");
            Console.WriteLine("**************************");

            // Items in the Array;
            Console.WriteLine("\nAll the items in the Array:");
            PrintValues(rndWords);
            Console.WriteLine("");

            // Sort the above array ascending;
            Console.WriteLine("\nSorting Array:");
            Array.Sort(rndWords);
            PrintValues(rndWords);
            Console.WriteLine("");

            timer.Start();
            // Search for an item in the Array | Example: Laptop;
            // Positive test
            Console.WriteLine("\nBinarySearch for 'Laptop':");
            var index1 = Array.BinarySearch(rndWords, "Laptop");
            bsearch.Search(rndWords, index1);

            //Search for an item in the Array | Example: IceCream;
            // Negative test
            Console.WriteLine("\nBinarySearch for 'IceCream':");
            var index2 = Array.BinarySearch(rndWords, "IceCream");
            bsearch.Search(rndWords, index2);

            timer.Stop();
            Console.WriteLine("Time needed for search: " + timer.Duration(TimeResolution.Seconds));
            Console.WriteLine("\nPress a key to continue");
            Console.ReadKey(true);
        }

        public static void PrintValues(IEnumerable rndWords)
        {
            foreach (var rndWord in rndWords)
            {
                Console.Write(rndWord + ", ");
            }
        }
    }
}