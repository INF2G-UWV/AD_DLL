using System;
using DLL;

namespace INF2G_DLL.Chapters.Chapter2
{
    /// <summary>
    ///     Test class for custom ArrayList feature.
    /// </summary>
    public class ArrayListTest
    {
        //fields
        private static readonly ArrayList<int> testList = new ArrayList<int>();

        /// <summary>
        ///     Main execution code.
        /// </summary>
        /// <param name="args"></param>
        public static void Run(string[] args)
        {
            TestArrayList();
        }

        /// <summary>
        ///     Test the ArrayList.
        /// </summary>
        private static void TestArrayList()
        {
            //Add values to arraylist
            for (var i = 0; i < 50; i++)
            {
                testList.Add(i);
            }

            //Add extra value
            testList.Add(48);

            //Print the ArrayList
            PrintArrayList();

            Console.WriteLine("Please select a value to remove: ");
            var input = Console.ReadLine();

            //Remove a value that user has specified
            int value;
            if (int.TryParse(input, out value))
            {
                testList.Remove(value);
                Console.WriteLine("Removal succesful!");
            }

            //Print the list again
            PrintArrayList();

            //Enter to exit
            Console.ReadLine();
        }

        /// <summary>
        ///     Print all the values of the ArrayList.
        /// </summary>
        private static void PrintArrayList()
        {
            Console.WriteLine("ArrayList has the following numbers: ");

            //Iterate through ArrayList and print the values
            for (var i = 0; i < testList.Length(); i++)
            {
                Console.WriteLine(testList.Get(i));
            }
        }
    }
}