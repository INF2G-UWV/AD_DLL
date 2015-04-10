using System;
using System.Linq;

namespace DLL
{
    /// <summary>
    ///     CStack
    ///     Author: Xing Woo - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CStack<T> where T : IComparable
    {
        //Fields stack
        private readonly int capacity;
        private readonly T[] stack;
        private int top;
        //Constructor Stack expects a maximum space for elements
        public CStack(int maxElements)
        {
            capacity = maxElements;
            stack = new T[capacity];
            top = -1;
        }

        /// <summary>
        ///     It pushed an generic item into the stack
        ///     When top == same as capacity it will returns an invalid number
        ///     When not the same, it will pushed it into the stack
        /// </summary>
        /// <param name="item"></param>
        /// <returns>int</returns>
        public int Push(T item)
        {
            if (top == capacity - 1)
            {
                return -1;
            }
            // insert elementt into stack
            top = top + 1;
            stack[top] = item;
            return 0;
        }

        /// <summary>
        ///     The Pop method, is like a remove method. It will the last item LIFO
        /// </summary>
        /// <returns>The removed item or the temponary default</returns>
        public T Pop()
        {
            T removeItem;
            var temp = default(T);
            //checking underflow
            if (stack.Count() != 0)
            {
                if (!(top <= 0))
                {
                    removeItem = stack[top];
                    top = top - 1;
                    return removeItem;
                }
            }
            else
            {
                Console.WriteLine("The stack is empty");
            }

            return temp;
        }

        /// <summary>
        ///     The peep method is get a value of the stack
        /// </summary>
        /// <param name="position"></param>
        /// <returns>Returns the stack, with an givin position</returns>
        public T Peep(int position)
        {
            // temponary generic variable, to set the variable
            var temp = default(T);
            if (stack.Count() != 0)
            {
                //check if Position is Valid or not
                if (position < capacity && position >= 0)
                {
                    return stack[position];
                }
            }
            else
            {
                Console.WriteLine("The stack is empty");
            }
            return temp;
        }

        /// <summary>
        ///     Peek don't changes the order of the stack, but get the last in of
        ///     the order in the stack.
        /// </summary>
        /// <param name=""></param>
        /// <returns>If true return last in else catch exception</returns>
        public T Peek()
        {
            // temponary generic variable, to set the variable
            var temp = default(T);

            if (stack.Count() != 0)
            {
                temp = stack.First();
            }
            else
            {
                Console.WriteLine("The stack is empty");
            }

            return temp;
        }

        /// <summary>
        ///     Get all stack items
        /// </summary>
        public void GetAllStackItems()
        {
            if (stack.Count() != 0)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}