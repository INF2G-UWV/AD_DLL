using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Chapter12;

namespace INF2G_DLL.Chapters.Chapter_12
{
    internal class BSTTEST
    {
        public static void Run(string[] args)
        {
            BinarySearchTree<int> tree =
                new BinarySearchTree<int>(44);
            for (int i = 0; i < 150; i++)
            {
                tree.Insert(i);
            }
            tree.PrintTree();
            Console.WriteLine();
            Console.WriteLine(tree.Contains(25).ToString());
            Console.WriteLine();
            for (int j = 25; j < 30; j++)
            {
                tree.Remove(j);
            }
            tree.PrintTree();
            Console.ReadLine();
        }
    }
}
