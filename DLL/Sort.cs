using System;
using System.Collections;

namespace DLL
{
    /// <summary>
    ///     Sort class.
    ///     Author: Martijn Buurman - INF2G.
    /// </summary>
    internal class Sort
    {
        /// <summary>
        ///     Main execution
        /// </summary>
        private static void Main()
        {
            var nums = new CArray<int>(100);
            for (var i = 0; i <= 100; i++)
            {
                nums.Insert(i);
            }
            nums.DisplayElements();
        }
    }

    /// <summary>
    ///     CArray generic class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CArray<T>
    {
        //Fields
        private readonly T[] arr;
        private readonly int upper;
        private Comparer comparer;
        private int numElements;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="size">int - size of array</param>
        public CArray(int size)
        {
            arr = new T[size];
            upper = size - 1;
            numElements = 0;
            comparer = Comparer.Default;
        }

        /// <summary>
        ///     Insert generic value into array
        /// </summary>
        /// <param name="item">generic item</param>
        public void Insert(T item)
        {
            //Add item
            arr[numElements] = item;

            //Increment count
            numElements++;
        }

        /// <summary>
        ///     Display all elements within the array
        /// </summary>
        public void DisplayElements()
        {
            //Loop through array
            for (var i = 0; i <= upper; i++)
            {
                //Write element
                Console.Write(arr[i] + " ");
            }
        }

        /// <summary>
        ///     Clear the array
        /// </summary>
        public void Clear()
        {
            //Loop through array
            for (var i = 0; i <= upper; i++)
            {
                //Nullify items
                arr[i] = default(T);
                numElements = 0;
            }
        }
    }
}