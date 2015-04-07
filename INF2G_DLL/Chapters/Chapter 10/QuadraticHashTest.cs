using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_10
{
    /// <summary>
    ///     Test for QuadraticHash
    /// </summary>
    internal class QuadraticHashTest
    {
        private readonly QuadraticHash quadraticHash;
        //Constructor
        public QuadraticHashTest()
        {
            //bucketHash = new BucketHash();
            quadraticHash = new QuadraticHash();
            RunTest();
        }

        /// <summary>
        ///     Test
        /// </summary>
        private void RunTest()
        {
            quadraticHash.Insert("Test");
            quadraticHash.Insert("Test");
            Console.WriteLine("Hashvalue of the word 'Test' is: " + quadraticHash.GetHashValue("Test"));
            CheckExists();
            quadraticHash.Remove("Test");
            Console.WriteLine("Test Removed, Checking..");
            CheckExists();
            Console.ReadKey();
        }

        private void CheckExists()
        {
            Console.WriteLine(quadraticHash.Exists("Test")
                ? "Test exists in the quadratic hash."
                : "Test does not exist!");
        }
    }
}