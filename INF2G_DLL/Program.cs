using System;
using DLL;

namespace INF2G_DLL
{
    internal class Program
    {
        private static readonly ArrayList<int> testList = new ArrayList<int>();

        private static void Main(string[] args)
        {
            TestArrayList();
        }

        public static void TestArrayList()
        {
            for (var i = 0; i < 50; i++)
            {
                testList.Add(i);
            }
            testList.Add(48);

            PrintArrayList();

            Console.WriteLine("Please select a value to remove: ");
            var input = Console.ReadLine();

            int value;
            if (int.TryParse(input, out value))
            {
                testList.Remove(value);
                Console.WriteLine("Removal succesful!");
            }

            PrintArrayList();

            Console.ReadLine();
        }

        public static void PrintArrayList()
        {
            Console.WriteLine("ArrayList has the following numbers: ");

            for (var i = 0; i < testList.Length(); i++)
            {
                Console.WriteLine(testList.Get(i));
            }
        }
    }
}