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
        private readonly BucketHash bucketHash;

        /// <summary>
        ///     Constructor
        /// </summary>
        public BucketHashTest()
        {
            bucketHash = new BucketHash();
            RunTest();
        }

        /// <summary>
        ///     Main test
        /// </summary>
        private void RunTest()
        {
            while (true)
            {
                Console.WriteLine("Bucket Hash Test");
                Console.WriteLine("");
                Console.WriteLine("Please type a string or word to be inserted in the BucketHash:");
                Console.Write("> ");

                //Read string from input
                var inputValue = Console.ReadLine();

                //Insert into BucketHash
                bucketHash.Insert(inputValue);

                //Print hashvalue
                Console.WriteLine("Hashvalue of the word {0} is: " + bucketHash.GetHashValue(inputValue), inputValue);

                //Check exists
                Console.WriteLine(
                    bucketHash.Exists(inputValue)
                        ? "{0} also exists in the bucket hash"
                        : "{0} does not exist, something went wrong!", inputValue);

                //Check for exit
                if (ExitInput())
                {
                    Console.Clear();
                    RunTest();
                }
                break;
            }
        }

        /// <summary>
        ///     Check if user wants to try again.
        /// </summary>
        /// <returns>exit - boolean</returns>
        private bool ExitInput()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Try again (y/n)?");
                var inputKey = Console.ReadKey();
                if (inputKey.Key.Equals(ConsoleKey.Y))
                {
                    return true;
                }
                if (inputKey.Key.Equals(ConsoleKey.N))
                {
                    return false;
                }
                Console.Clear();
                Console.WriteLine("Bad input!");
            }
        }
    }
}