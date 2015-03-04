using System;

namespace DLL
{
    /// <summary>
    /// Custom ArrayList class.
    /// Provides similar functionality to the internal C# ArrayList class.
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class ArrayList<T>
    {
        //Array to store data
        private T[] list = new T[0];

        /// <summary>
        /// Increase the size of the array by one, and add a generic to the array.
        /// </summary>
        /// <param name="item">Generic Type</param>
        public void Add(T item)
        {
            Array.Resize(ref list, list.Length + 1);
            list[list.Length - 1] = item;
        }

        /// <summary>
        /// Returns the number of items in the array.
        /// </summary>
        /// <returns>Int - number of items</returns>
        public int Length()
        {
            return list.Length;
        }

        /// <summary>
        /// Get an item at the specified index value.
        /// </summary>
        /// <param name="item">Int - index value</param>
        /// <returns>Generic - item</returns>
        public T Get(int item)
        {
            return list[item];
        }

        /// <summary>
        /// Removes item(s) from the array.
        /// First checks the entire array for matching item(s),
        /// then shifts all succeeding items back by the number of items to be removed,
        /// and finnally removes the same number of items at the tail end of the array.
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
    }
}