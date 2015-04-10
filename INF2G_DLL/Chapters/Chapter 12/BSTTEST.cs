using System;
using DLL;

namespace DLL_Test.Chapters.Chapter_12
{
    /// <summary>
    ///     Binary Search Tree Test.
    ///     Author: Xing Woo - INF2G
    /// </summary>
    internal class BstTest
    {
        /// <summary>
        ///     Main test method.
        /// </summary>
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("********************************");
            Console.WriteLine("****Binary Search Tree Test****");
            Console.WriteLine("*******************************");
            //Create new tree
            var tree =
                new BinarySearchTree<int>(44);
            //Insert values
            for (var i = 0; i < 150; i++)
            {
                tree.Insert(i);
            }

            Console.WriteLine("Current tree:");
            //Print
            tree.PrintTree();
            Console.WriteLine();
            Console.WriteLine(tree.Contains(25).ToString());
            Console.WriteLine();

            Console.WriteLine("Removing values 25-29\n");
            //Remove values
            for (var j = 25; j < 30; j++)
            {
                tree.Remove(j);
            }
            //Print
            Console.WriteLine("New tree:");
            tree.PrintTree();
            Console.ReadLine();
        }
    }
}