using System.Collections;

namespace DLL
{
    /// <summary>
    ///     Sorting class.
    ///     Provides various sorting algorithms.
    ///     Author: INF2G.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Sorting<T>
    {
        private readonly Comparer comparer;
        private T[] array;

        /// <summary>
        ///     Constructor.
        ///     Create the sorting class.
        ///     Uses a generic array for storage.
        /// </summary>
        /// <param name="array">Generic array</param>
        public Sorting(T[] array)
        {
            this.array = array;
            comparer = Comparer.Default;
        }

        /// <summary>
        ///     Bubblesort.
        ///     Sorts the array alfabetically. Every data type is supported.
        /// </summary>
        /// <param name="array">Generic array</param>
        public void BubbleSort(T[] array)
        {
            //Outer loop
            for (var outer = array.Length - 1; outer > 1; outer--)
            {
                //Inner loop
                for (var inner = 0; inner < outer; inner++)
                {
                    //Compare values
                    if (comparer.Compare(array[inner], array[inner + 1]) > 0)
                    {
                        var temp = array[inner];
                        array[inner] = array[inner + 1];
                        array[inner + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        ///     Smart Bubble Sort.
        ///     Functions the same as Bubble Sort, but now stops searching when no more changes in a certain pass were made.
        /// </summary>
        /// <param name="array">Generic array</param>
        public void SmartBubbleSort(T[] array)
        {
            for (var outer = array.Length - 1; outer > 1; outer--)
            {
                var valueChanged = false;
                for (var inner = 0; inner < outer; inner++)
                {
                    if (comparer.Compare(array[inner], array[inner + 1]) > 0)
                    {
                        var temp = array[inner];
                        array[inner] = array[inner + 1];
                        array[inner + 1] = temp;
                        valueChanged = true;
                    }
                }
                if (!valueChanged)
                {
                    break;
                }
            }
        }

        /// <summary>
        ///     InsertionSort.
        ///     Sorts the generic array alfabetically.
        /// </summary>
        /// <param name="array">Generic array</param>
        public void InsertionSort(T[] array)
        {
            //variables
            int inner;
            T temp;

            //Outer loop
            for (var outer = 1; outer <= array.Length - 1; outer++)
            {
                //Temp
                temp = array[outer];
                inner = outer;
                //Inner loop
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