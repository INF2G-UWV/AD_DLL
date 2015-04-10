using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_10
{
    /// <summary>
    ///     Test for BucketHash
    ///     Author: Marcel Schoeber - INF2G
    /// </summary>
    internal class BucketHashTest
    {
        private static BucketHash bucketHash;

        public static void Run()
        {
            bucketHash = new BucketHash();
            RunTest();
        }

        /// <summary>
        ///     Main Test
        /// </summary>
        private static void RunTest()
        {
            //Check if running
            var running = true;

            //print menu
            Console.Clear();
            Console.WriteLine("************************");
            Console.WriteLine("****Bucket Hash Test****");
            Console.WriteLine("************************");
            Console.WriteLine("(1) Add new item to hash.");
            Console.WriteLine("(2) Remove item from hash.");
            Console.WriteLine("(3) Check if item exists.");
            Console.WriteLine("(4) Get a hashvalue from input.");
            Console.WriteLine("(5) Print the contents of the hashtable.");
            Console.WriteLine("(X) Exit");
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

            else if (input.Key.Equals(ConsoleKey.X) || input.Key.Equals(ConsoleKey.Backspace))
            {
                running = false;
            }
            else
            {
                Console.WriteLine("\nUnrecognized input!");
                Console.ReadKey(true);
            }

            if (running)
            {
                //loopx
                RunTest();
            }
        }

        private static void AddList()
        {
            Console.WriteLine("Please type a string or word to be inserted in the bucket hash:");
            Console.Write("> ");

            //Read string from input
            var input = Console.ReadLine();

            //Insert into QuadraticHash
            bucketHash.Insert(input);

            //Get hashvalue
            Console.WriteLine("\nHashvalue of the word '{0}' is: {1}", input,
                bucketHash.GetHashValue(input));
            Console.WriteLine("\nPress a key to continue");
            Console.ReadKey(true);
        }

        /// <summary>
        ///     Remove item from hash.
        /// </summary>
        private static void RemoveList()
        {
            Console.WriteLine("Please type a string or word to be removed from bucket hash:");
            Console.Write("> ");

            //Read string from input
            var input = Console.ReadLine();

            //Check if exists
            if (bucketHash.Exists(input))
            {
                //Remove item
                bucketHash.Remove(input);

                Console.WriteLine(!bucketHash.Exists(input) ? "\nSuccesfully removed!" : "\nRemove failed!");
            }
            else
            {
                Console.WriteLine("\nItem does not exist!");
            }
            Console.WriteLine("\nPress a key to continue");
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

            //Get hashvalue
            Console.WriteLine("\nHashvalue of the word '{0}' is: {1}", input,
                bucketHash.GetHashValue(input));
            Console.WriteLine("\nPress a key to continue");
            Console.ReadKey(true);
        }

        /// <summary>
        ///     Print the contents of the hash.
        /// </summary>
        private static void PrintList()
        {
            Console.WriteLine("Contents of hashtable (item - hashvalue):");
            Console.WriteLine();
            //Fetch list
            var contents = bucketHash.GetList();

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
                Console.WriteLine("Hashtable is empty!");
            }
            Console.WriteLine("\nPress a key to continue");
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
            Console.WriteLine(bucketHash.Exists(input)
                ? "\n{0} exists in the bucket hash."
                : "\n{0} does not exist!", input);
            Console.WriteLine("\nPress a key to continue");
            Console.ReadKey(true);
        }
    }
}