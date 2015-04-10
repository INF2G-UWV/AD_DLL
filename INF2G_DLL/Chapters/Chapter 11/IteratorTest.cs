using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_11
{
    /// <summary>
    ///     Iterator Test.
    ///     Generates a list of integers and then iterates through them.
    ///     Author: Marcel Schoeber - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class IteratorTest<T>
    {
        /// <summary>
        ///     Main execution
        /// </summary>
        public static void Run()
        {
            RunTest();
        }

        /// <summary>
        ///     Run the iterator test.
        /// </summary>
        private static void RunTest()
        {
            //Create new iterator
            var iterator = new Iterator<int>(GenerateList());
            Console.Clear();
            Console.WriteLine("*********************");
            Console.WriteLine("****Iterator Test****");
            Console.WriteLine("*********************\n");
            Console.WriteLine("Iterate trough list of random generated numbers:\n");

            //Iterate through items
            while (!iterator.AtEnd())
            {
                //Write current item
                Console.Write("{0}\t", iterator.GetCurrent());
                //Goto next item
                iterator.NextLink();
            }

            //Ask  if the user want to do another run
            Console.WriteLine("\nRun again (y/n)");
            RunAgain();
        }

        /// <summary>
        ///     Checks if user wants to run test again.
        ///     In case user presses y, test starts again.
        ///     If user presses n, test will exit.
        ///     Any other key will be ignored.
        /// </summary>
        private static void RunAgain()
        {
            var input = Console.ReadKey(true);
            if (input.Key.Equals(ConsoleKey.Y))
            {
                Console.Clear();
                RunTest();
            }
            else if (input.Key.Equals(ConsoleKey.N))
            {
            }
            else
            {
                RunAgain();
            }
        }

        /// <summary>
        ///     Generate a LinkedList with random integers.
        /// </summary>
        /// <returns>LinkedList - Random Generated LinkedList</returns>
        private static LinkedList<int> GenerateList()
        {
            //Create new random
            var rnd = new Random();

            //Create random value
            var value = rnd.Next(1, 150);

            //Create LinkedList with random value in header
            var list = new LinkedList<int>(value);

            //Add many other nodes to LinkedList
            for (var i = 0; i < 100; i++)
            {
                var previous = value;
                value = rnd.Next(50, 150);
                list.Insert(value, previous);
            }
            return list;
        }
    }
}