using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_5
{
    internal class StackTest
    {
        public static void Run(string[] args)
        {
            CStack<string> stack = new CStack<string>(4);
            stack.Push("test1");
            stack.Push("test2");
            stack.Push("test3");
            stack.Push("test4"); 
            stack.Push("test5");

            Console.WriteLine(stack.Peek());
            stack.GetAllStackItems();
            Console.ReadLine();
        }
    }
}
