using System;
using System.Linq;

namespace DLL
{
    /// <summary>
    ///     Custom ArrayList class.
    ///     Provides similar functionality to the internal C# ArrayList class.
    ///     Author: Marcel Schoeber - INF2G
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class ArrayList<T>
    {
        //Array to store data
        private T[] list = new T[0];

        /// <summary>
        ///     Increase the size of the array by one, and add a generic to the array.
        /// </summary>
        /// <param name="item">Generic Type</param>
        public void Add(T item)
        {
            Array.Resize(ref list, list.Length + 1);
            list[list.Length - 1] = item;
        }

        /// <summary>
        ///     Returns the number of items in the array.
        /// </summary>
        /// <returns>Int - number of items</returns>
        public int Length()
        {
            return list.Length;
        }

        /// <summary>
        ///     Get an item at the specified index value.
        /// </summary>
        /// <param name="item">Int - index value</param>
        /// <returns>Generic - item</returns>
        public T Get(int item)
        {
            return list[item];
        }

        /// <summary>
        ///     Removes item(s) from the array.
        ///     First checks the entire array for matching item(s),
        ///     then shifts all succeeding items back by the number of items to be removed,
        ///     and finnally removes the same number of items at the tail end of the array.
        /// </summary>
        /// <param name="item">Generic - item to be removed</param>
        public void Remove(T item)
        {
            //Array of items to be removed
            var itemToRemove = new int[list.Length];
            //Number of items to be removed
            var numberOfItems = 0;

            //Check for matches, and add matched index values at the itemsToRemove array.
            for (var i = 0; i < list.Length; i++)
            {
                if (list[i].Equals(item))
                {
                    itemToRemove[numberOfItems] = i;
                    numberOfItems++;
                }
            }

            //Shift the array back at the matched index values
            for (var x = 0; x < numberOfItems; x++)
            {
                for (var z = itemToRemove[x]; z < list.Length - 1; z++)
                {
                    list[z] = list[z + 1];
                }
            }

            //Cut out the number of removed items at the tail end of the array.
            Array.Resize(ref list, list.Length - numberOfItems);
        }

        /// <summary>
        ///     Remove item at given index value.
        /// </summary>
        /// <param name="index">Int - index value</param>
        public void RemoveAt(int index)
        {
            for (var i = index; i < list.Length - 1; i++)
            {
                list[i] = list[i + 1];
            }
            Array.Resize(ref list, list.Length - 1);
        }

        public void InsertAt(int index, T item)
        {
            if (index <= Length())
            {
                list[index] = item;
            }
        }

        /// <summary>
        ///     Clears the array;
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref list, 0);
        }

        /// <summary>
        ///     Check wether item exists in array.
        ///     Returns true if item exists.
        /// </summary>
        /// <param name="item">Generic - item</param>
        /// <returns>Bool - item exists true/false</returns>
        public bool Contains(T item)
        {
            var itemExists = false;
            foreach (var t in list.Where(t => t.Equals(item)))
            {
                itemExists = true;
            }
            return itemExists;
        }

        /// <summary>
        ///     Checks if item exists in array,
        ///     and returns the index value of the first item found.
        ///     If an item is not found, -1 is returned;
        /// </summary>
        /// <param name="item">Generic - item</param>
        /// <returns>Int - index value</returns>
        public int IndexOf(T item)
        {
            var index = -1;
            for (var i = 0; i < list.Length; i++)
            {
                if (list[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        ///     Returns the list in array format.
        /// </summary>
        /// <returns>Generic Array - list of items</returns>
        public T[] ToArray()
        {
            return list;
        }

        /// <summary>
        ///     Moves an object from one index value to another.
        /// </summary>
        /// <param name="from">Int - source index value</param>
        /// <param name="to">Int - destination index value</param>
        public void Move(int from, int to)
        {
            list[to] = list[from];
            RemoveAt(from);
        }

        public bool IsEmpty()
        {
            return Length() <= 0;
        }

        public void Update(T one, T two)
        {
            var indexOne = IndexOf(one);
            if (indexOne > 0)
            {
                InsertAt(indexOne, two);
            }
        }

        /// <summary>
        ///     Swaps two items in array.
        /// </summary>
        /// <param name="one">Int - position of first item</param>
        /// <param name="two">Int - position of second item</param>
        public void Swap(int one, int two)
        {
            var itemTwo = list[two];
            list[two] = list[one];
            list[one] = itemTwo;
        }

        /// <summary>
        ///     Print contents
        /// </summary>
        public void ShowList()
        {
            for (var i = 0; i < Length(); i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}