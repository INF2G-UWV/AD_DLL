using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_3
{
    class Sort
    {

        public static void Run(string[] args)
        {
            SortingProgram();
        }

        public static void SortingProgram()
        {
            ArrayList RandomString = new ArrayList();

            string strings = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            string EmptyString = "";
            string[] stringArray = new string[10];
            string[] sortedArray = new string[10];
            Random random = new Random(100);
            Sorting<string> sort = new Sorting<string>(stringArray);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    EmptyString += strings[random.Next(strings.Length)];
                }
                stringArray.SetValue(EmptyString, i);
                EmptyString = "";
            }

            stringArray.CopyTo(sortedArray, 0);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter a key from the list: ");
                Console.WriteLine("(p) Print a unsorted list.");
                Console.WriteLine("(b) Print a list sorted with the BubbleSort.");
                Console.WriteLine("(i) Print a list sorted with the InsertionSort.");
                Console.WriteLine("(c) Clear console");
                Console.WriteLine("(x) Exit program");
                Console.WriteLine();
                Console.WriteLine();

                string choice = Console.ReadLine();
                choice = choice.ToLower();
                char[] oneChar = choice.ToCharArray();

                switch (oneChar[0])
                {
                    case 'p':
                        Console.WriteLine();
                        Console.WriteLine("An unsorted list");
                        Console.WriteLine();
                        foreach (string singleString in stringArray)
                        {
                            Console.WriteLine(singleString);
                        }
                        break;
                    case 'b':
                        Console.WriteLine();
                        Console.WriteLine("List sorted by the BubbleSort");
                        Console.WriteLine();
                        sort.BubbleSort(sortedArray);
                        foreach (string singleString in sortedArray)
                        {
                            Console.WriteLine(singleString);
                        }
                        break;
                    case 'i':
                        Console.WriteLine();
                        Console.WriteLine("List sorted by the InsertionSort");
                        Console.WriteLine();
                        sort.InsertionSort(sortedArray);
                        foreach (string singleString in sortedArray)
                        {
                            Console.WriteLine(singleString);
                        }
                        break;
                    case 'c':
                        Console.Clear();
                        break;
                    case 'x':
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
