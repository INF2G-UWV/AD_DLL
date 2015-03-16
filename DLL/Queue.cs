using System;
using System.Collections.Generic;
using System.Linq;

namespace DLL
{
    /// <summary>
    ///     Queue Class
    ///     Chapter 5
    /// </summary>
    public class Queue<T> where T : IComparable<T>
    {
        // Make a List to store all the items in it;
        private List<T> pqList;
        
        public Queue()
        {
            pqList = new List<T>();
        }

        // Add items to the queue. Add new items as the first Queue (First in, First out);
        public void Enqueue(T item)
        {
            pqList.Insert(0, item);
        }

        // Delete the first item from the Queue. (First in, First Out);
        public T Dequeue()
        {
            T frontItem = pqList[0];
            pqList.RemoveAt(0);
            return frontItem;
        }

        // Look at the next item in the Queue;
        public T Peek()
        {
            return pqList.First();
        }

        // The total Queue's that are left in the Queue;
        public int Count()
        {
            return pqList.Count;
        }

        // Empty the list;
        public void Clear()
        {
            pqList.Clear();
        }

        // Checks for items in the Queue. If it does - return TRUE | If it doesn't - return false;
        public bool Contains(T item)
        {
            return pqList.Contains(item);
        }
    }

}