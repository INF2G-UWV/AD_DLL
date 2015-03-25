using System;
using DLL;

namespace INF2G_DLL.Chapters.Chapter_5
{
    internal class StackTest
    {
        public static void Run(string[] args)
        {
            //Initialize a generic type CSstack obj, with a 4 spots
            var stack = new CStack<string>(4);
            //Push 5 objects into stack, where positions will be filled
            stack.Push("test1");
            stack.Push("test2");
            stack.Push("test3");
            stack.Push("test4");
            stack.Push("test5");

            //Methods of stack
            Console.WriteLine(stack.Peek());
            stack.GetAllStackItems();
            Console.ReadLine();
        }
    }
}