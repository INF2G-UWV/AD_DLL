using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_10
{
    /// <summary>
    ///     Test for QuadraticHash
    ///     Author: Marcel Schoeber - INF2G
    /// </summary>
    internal class QuadraticHashTest
    {
        private static QuadraticHash quadraticHash;

        public static void Run()
        {
            quadraticHash = new QuadraticHash();
            RunTest();
        }

        /// <summary>
        ///     Main Menu
        /// </summary>
        private static void RunTest()
        {
            var running = true;

            //Check if active
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Quadratic Hash Test");
                Console.WriteLine("");
                Console.WriteLine("1.Add new item to hash.");
                Console.WriteLine("2.Remove item from hash.");
                Console.WriteLine("3.Check if item exists.");
                Console.WriteLine("4.Get a hashvalue from input.");
                Console.WriteLine("5.Print the contents of the hashtable.");
                Console.WriteLine("6.Exit");
                var input = Console.ReadKey(true);
                Console.WriteLine();

                if (input.Key.Equals(ConsoleKey.D1))
                {
                    //Add item
                    AddList();
                }

                else if (input.Key.Equals(ConsoleKey.D2))
                {
                    //Remove item
                    RemoveList();
                }

                else if (input.Key.Equals(ConsoleKey.D3))
                {
                    //Check item
                    CheckExists();
                }

                else if (input.Key.Equals(ConsoleKey.D4))
                {
                    //Get hash value
                    GetHashValue();
                }

                else if (input.Key.Equals(ConsoleKey.D5))
                {
                    //Print contents of hashtable
                    PrintList();
                }

                else if (input.Key.Equals(ConsoleKey.D6))
                {
                    //Exit
                    running = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Unrecognized input!");
                    Console.ReadKey(true);
                }
            }
        }

        private static void AddList()
        {
            Console.WriteLine("Please type a string or word to be inserted in the quadratic hash:");
            Console.Write("> ");

            //Read string from input
            var input = Console.ReadLine();

            //Insert into QuadraticHash
            quadraticHash.Insert(input);

            Console.WriteLine();
            //Get hashvalue
            Console.WriteLine("Hashvalue of the word '{0}' is: {1}", input,
                quadraticHash.GetHashValue(input));
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
        }

        /// <summary>
        ///     Remove item from hash.
        /// </summary>
        private static void RemoveList()
        {
            Console.WriteLine("Please type a string or word to be removed from quadratic hash:");
            Console.Write("> ");

            //Read string from input
            var input = Console.ReadLine();

            //Check if exists
            if (quadraticHash.Exists(input))
            {
                //Remove item
                quadraticHash.Remove(input);
                Console.WriteLine();
                Console.WriteLine(!quadraticHash.Exists(input) ? "Succesfully removed!" : "Remove failed!");
            }
            else
            {
                Console.WriteLine("Item does not exist!");
            }
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
        }

        /// <summary>
        ///     Get the hash value of input.
        /// </summary>
        private static void GetHashValue()
        {
            Console.WriteLine("Please type a string or word to get it's respective hashvalue:");
            Console.Write("> ");

            //Read string from input
            var input = Console.ReadLine();
            Console.WriteLine();

            //Get hashvalue
            Console.WriteLine("Hashvalue of the word '{0}' is: {1}", input,
                quadraticHash.GetHashValue(input));
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
        }

        /// <summary>
        ///     Print the contents of the hash.
        /// </summary>
        private static void PrintList()
        {
            Console.WriteLine("Contents of hash (item - hashvalue):");
            Console.WriteLine();
            //Fetch list
            var contents = quadraticHash.GetList();

            //Check if empty
            if (contents.Count > 0)
            {
                //Print list
                foreach (var item in contents)
                {
                    Console.WriteLine("{0} - {1}", item.Key, item.Value);
                }
            }
            else
            {
                Console.WriteLine("Hash is empty!");
            }
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
        }

        /// <summary>
        ///     Check if value exists in hash.
        /// </summary>
        private static void CheckExists()
        {
            Console.WriteLine("Check if the following item exists: ");
            Console.Write(">");
            //Read input
            var input = Console.ReadLine();
            //Verify if exists or not
            Console.WriteLine(quadraticHash.Exists(input)
                ? "{0} exists in the quadratic hash."
                : "{0} does not exist!", input);
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
        }
    }
}