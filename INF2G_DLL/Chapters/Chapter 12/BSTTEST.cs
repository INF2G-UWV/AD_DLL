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
        /// <param name="args"></param>
        public static void Run(string[] args)
        {
            //Create new tree
            var tree =
                new BinarySearchTree<int>(44);
            //Insert values
            for (var i = 0; i < 150; i++)
            {
                tree.Insert(i);
            }
            //Print
            tree.PrintTree();
            Console.WriteLine();
            Console.WriteLine(tree.Contains(25).ToString());
            Console.WriteLine();
            //Remove values
            for (var j = 25; j < 30; j++)
            {
                tree.Remove(j);
            }
            //Print
            tree.PrintTree();
            Console.ReadLine();
        }
    }
}