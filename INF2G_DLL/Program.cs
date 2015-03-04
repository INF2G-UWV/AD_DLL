using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace INF2G_DLL
{
    class Program
    {
        private static ArrayList<int> testList = new ArrayList<int>();
        static void Main(string[] args)
        {
            TestArrayList();

        }

        public static void TestArrayList()
        {
            for (int i = 0; i < 50; i++)
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

            for (int i = 0; i < testList.Length(); i++)
            {
                Console.WriteLine(testList.Get(i));
            }

           
            
        }
    }
}
