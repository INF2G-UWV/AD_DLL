using System.Collections;

namespace DLL
{
    public class Sorting<T>
    {
        private readonly Comparer comparer;
        private T[] array;

        /// <summary>
        ///     Het aanmaken van een sorting class. Een array moet als parameter meegegeven worden.
        ///     Het maakt niet uit van welk type object, doordat de class generiek is.
        /// </summary>
        /// <param name="array"></param>
        public Sorting(T[] array)
        {
            this.array = array;
            comparer = Comparer.Default;
        }

        /// <summary>
        ///     Het sorteren van een Array op alfabetische volgorde. Alle mogelijke objecten kunnen erin.
        ///     Van strings tot integers.
        /// </summary>
        /// <param name="array"></param>
        public void BubbleSort(T[] array)
        {
            for (var outer = array.Length - 1; outer > 1; outer--)
            {
                for (var inner = 0; inner < outer; inner++)
                {
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
        /// Smart Bubble Sort.
        /// Functions the same as Bubble Sort, but now stops searching once no more changes in a certain pass are made.
        /// </summary>
        /// <param name="array"></param>
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
        ///     Het sorteren van een Array op alfabetische volgorde. Alle mogelijke objecten kunnen erin.
        ///     Van strings tot integers.
        /// </summary>
        /// <param name="array"></param>
        public void InsertionSort(T[] array)
        {
            int inner;
            T temp;

            for (var outer = 1; outer <= array.Length - 1; outer++)
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