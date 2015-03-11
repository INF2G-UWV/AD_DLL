using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    /// <summary>
    ///     Custom MinMax class.
    ///     Chapter 4 search 
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class MinMax<T> where T : IComparable
    {
        //Fields MinMax
        private T[] min;
        private T[] max;

        //Constructor MinMax expects generics objects
        public MinMax(T[] min, T[] max)
        {
            this.min = min;
            this.max = max;
        }

        /*
         * Method to find minimum value in an array
         * Returns the minimum value
         * Generic type method
         */
        public T FindMinimum()
        {
            T minimum = min[0];
            for (int i = 0; i < min.Length; i++)
            {
                if (min[i].CompareTo(minimum) < 0)
                {
                    minimum = min[i];
                }
            }
            return minimum;
        }

        /*
         * Method to find maximum value in an array
         * Returns the maximum value
         * Generic type method
         */
        public T FindMaximum()
        {
            T maximum = max[0];
            for (int i = 0; i < max.Length; i++)
            {
                if (max[i].CompareTo(maximum) > 0)
                {
                    maximum = max[i];
                }
            }
            return maximum;
        }
    }
}
