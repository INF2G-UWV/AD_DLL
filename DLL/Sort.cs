using System;
using System.Collections;

namespace DLL
{
    internal class Sort
    {
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

    public class CArray<T>
    {
        private readonly T[] arr;
        private readonly int upper;
        private Comparer comparer;
        private int numElements;

        public CArray(int size)
        {
            arr = new T[size];
            upper = size - 1;
            numElements = 0;
            comparer = Comparer.Default;
        }

        public void Insert(T item)
        {
            arr[numElements] = item;
            numElements++;
        }

        public void DisplayElements()
        {
            for (var i = 0; i <= upper; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public void Clear()
        {
            for (var i = 0; i <= upper; i++)
            {
                arr[i] = default(T);
                numElements = 0;
            }
        }
    }
}