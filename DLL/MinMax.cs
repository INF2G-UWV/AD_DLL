using System;
using System.Linq;

namespace DLL
{
    /// <summary>
    ///     Custom MinMax class.
    ///     Chapter 4 search
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    public class MinMax<T> where T : IComparable
    {
        private readonly T[] max;
        //Fields MinMax
        private readonly T[] min;
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
            var minimum = min[0];
            foreach (var t in min.Where(t => t.CompareTo(minimum) < 0))
            {
                minimum = t;
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
            var maximum = max[0];
            foreach (var t in max.Where(t => t.CompareTo(maximum) > 0))
            {
                maximum = t;
            }
            return maximum;
        }
    }
}