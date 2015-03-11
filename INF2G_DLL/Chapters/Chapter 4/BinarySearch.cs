using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_3
{
    internal class BinarySearch
    {
        public static void Run(string[] args)
        {
            // Create an array and fill it;
            string[] rndWords = {"Pizza", "Spaghetti", "Bread", "Chickingwings", "Cheese", "Salad","Hallo"
                                ,"Test", "NogEenTest", "Auto", "Fiets", "Motor", "Vrachtwagen", "Laptop", "Desktop"
                                ,"Apple", "Android", "Windows", "Linux", "GPU", "CPU", "Mouse", "Screen"};

            // Create a Generic BinarySearch;
            BinarySearch<string> bsearch = new BinarySearch<string>();

            // Sort the above array ascending;
            Array.Sort(rndWords);

            // Search for an item in the Array | Example: Bread;
            // Positive test
            Console.WriteLine("\nBinarySearch for 'Laptop':");
            int index1 = Array.BinarySearch(rndWords, "Laptop");
            bsearch.Search(rndWords, index1);

            //Search for an item in the Array | Example: IceCream;
            // Negative test
            Console.WriteLine("\nBinarySearch for 'IceCream':");
            int index2 = Array.BinarySearch(rndWords, "IceCream");
            bsearch.Search(rndWords, index2);

            Console.ReadLine();
        }
    }
}
