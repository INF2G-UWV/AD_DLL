﻿using System;

namespace DLL
{
    /// <summary>
    ///     BinarySearch Class
    ///     Chapter 3
    ///     Author: Selami Çetingüney - INF2G
    /// </summary>
    public class BinarySearch<T> where T : IComparable<T>
    {
        public void Search<T>(T[] array, int index)
        {
            // If the Array[] index is negative;
            if (index < 0)
            {
                // It represents by bitwise the next larger element in the array;
                index = ~index;

                // If the value/item couldn't be found in the Array[] index;
                Console.Write("Not found. Searching between: ");

                // When the Array[] index is empty, 
                // it searches at the beginning of the array;
                if (index == 0)
                {
                    Console.Write("beginning of array and ");
                }
                // Prints out the value/item where it stopped searching.
                // This is all done with ascending order in the Array[];
                else
                {
                    Console.Write("{0} and ", array[index - 1]);
                }

                // When the index equals Array[], 
                // it searches at the end of the array;
                if (index == array.Length)
                {
                    Console.WriteLine("the end of array.");
                }
                // Prints out the value/item that comes next in line where it has stopped.
                // This is all done with ascending order in the Array[];
                else
                {
                    Console.WriteLine("{0}.", array[index]);
                }
            }
            else
            {
                // When the value/item is found in the Array[], 
                // it prints out the index location in the Array[];
                Console.WriteLine("Found at index {0}.", index);
            }
        }
    }
}