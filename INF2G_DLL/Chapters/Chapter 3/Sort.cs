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
        /// <summary>
        ///     Main execution.
        /// </summary>
        /// <param name="args"></param>
        public static void Run(string[] args)
        {
            SortingProgram();
        }

        /// <summary>
        ///     Main sorting program.
        /// </summary>
        public static void SortingProgram()
        {
            // String with letters and numbers
            const string strings = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

            // empty string
            var emptyString = "";

            // Original array with string
            var stringArray = new string[10];

            // Array where the original array is being copied to
            var sortedArray = new string[10];

            // Random generator to create random strings
            var random = new Random(100);

            // Sorting class will be used to sort the arrays
            var sort = new Sorting<string>(stringArray);

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

            // Copy of the original array
            stringArray.CopyTo(sortedArray, 0);

            // While true (program is active), display the following output
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter a key from the list: ");
                Console.WriteLine("(p) Print a unsorted list.");
                Console.WriteLine("(b) Print a list sorted with the BubbleSort algorithm.");
                Console.WriteLine("(s) Print a list sorted with the SmartBubbleSort algorithm.");
                Console.WriteLine("(i) Print a list sorted with the InsertionSort algorithm.");
                Console.WriteLine("(c) Clear console");
                Console.WriteLine("(x) Exit program");
                Console.WriteLine();
                Console.WriteLine();

                // Reading input
                var choice = Console.ReadLine();

                // Convert input to lowercase
                if (choice != null)
                {
                    choice = choice.ToLower();

                    // Convert lowercase input to chararray
                    var oneChar = choice.ToCharArray();

                    // Switch to perform several different actions
                    switch (oneChar[0])
                    {
                        // Printing the original array
                        case 'p':
                            Console.WriteLine();
                            Console.WriteLine("An unsorted list");
                            Console.WriteLine();
                            foreach (var singleString in stringArray)
                            {
                                Console.WriteLine(singleString);
                            }
                            break;

                        // Sorting the original array with BubbleSort()
                        case 'b':
                            Console.WriteLine();
                            Console.WriteLine("List sorted by the BubbleSort algorithm");
                            Console.WriteLine();
                            sort.BubbleSort(sortedArray);
                            foreach (var singleString in sortedArray)
                            {
                                Console.WriteLine(singleString);
                            }
                            break;

                        // Sorting copied array with BubbleSort()
                        case 's':
                            Console.WriteLine();
                            Console.WriteLine("List sorted by the SmartBubbleSort algorithm");
                            Console.WriteLine();
                            sort.SmartBubbleSort(sortedArray);
                            foreach (var singleString in sortedArray)
                            {
                                Console.WriteLine(singleString);
                            }
                            break;

                        // Sorting copied array with InsertionSort()
                        case 'i':
                            Console.WriteLine();
                            Console.WriteLine("List sorted by the InsertionSort algorithm");
                            Console.WriteLine();
                            sort.InsertionSort(sortedArray);
                            foreach (var singleString in sortedArray)
                            {
                                Console.WriteLine(singleString);
                            }
                            break;

                        // Clearing the console
                        case 'c':
                            Console.Clear();
                            break;

                        // Exiting the program
                        case 'x':
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}