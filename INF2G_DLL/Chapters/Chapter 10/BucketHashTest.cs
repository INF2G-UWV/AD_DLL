using System;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_10
{
    /// <summary>
    /// Test for BucketHash
    /// </summary>
    internal class BucketHashTest
    {
        private readonly BucketHash bucketHash;

        //Constructor
        public BucketHashTest()
        {
            bucketHash = new BucketHash();
            RunTest();
        }

        /// <summary>
        /// Test
        /// </summary>
        private void RunTest()
        {
            bucketHash.Insert("Test");
            Console.WriteLine("Hashvalue of the word 'Test' is: " + bucketHash.GetHashValue("Test"));
            Console.WriteLine(bucketHash.Exists("Test")
                ? "Test also exists in the bucket hash"
                : "Test does not exist, something went wrong!");
            Console.ReadKey();
        }
    }
}