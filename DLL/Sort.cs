using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    class Sort
    {
        static void Main()
        {
            CArray<int> nums = new CArray<int>(100);
            for (int i = 0; i <= 100; i++)
            {
                nums.Insert(i);
            }
            nums.DisplayElements();
        }
    }

    public class CArray<T>
    {
        private T[] arr;
        private int upper;
        private int numElements;

        Comparer comparer;

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
            for (int i = 0; i <= upper; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public void Clear()
        {
            for (int i = 0; i <= upper; i++)
            {
                arr[i] = default(T);
                numElements = 0;
            }
        }
    }
}
