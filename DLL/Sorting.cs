using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Sorting<T>
    {
        private T[] array;

        private Comparer comparer;

        public Sorting(T[] array)
        {
            this.array = array;
            comparer = Comparer.Default;
        }

        public void BubbleSort(T[] array)
        {
            for (int outer = array.Length - 1; outer > 1; outer--)
            {
                for (int inner = 0; inner < outer; inner++)
                {
                    if (comparer.Compare(array[inner], array[inner + 1]) > 0)
                    {
                        T temp = array[inner];
                        array[inner] = array[inner + 1];
                        array[inner + 1] = temp;

                    }
                }
            }
        }

        public void InsertionSort(T[] array)
        {
            int inner;
            T temp;

            for (int outer = 1; outer <= array.Length - 1; outer++)
            {
                temp = array[outer];
                inner = outer;
                while (inner > 0 && comparer.Compare(array[inner - 1], temp) > 0)
                {
                    array[inner] = array[inner - 1];
                    inner -= 1;
                }
                array[inner] = temp;
            }
        }
    }
}
