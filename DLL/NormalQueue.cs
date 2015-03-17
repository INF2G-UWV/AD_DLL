using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DLL
{
    /// <summary>
    ///     Queue Class
    ///     Chapter 5
    /// </summary>
    public class NormalQueue<T> where T : IComparable<T>
    {
        // Make a List to store all the items in it;
        private LinkedList<T> qList;

        public NormalQueue()
        {
            qList = new LinkedList<T>();
        }

        // If the list is empty, add an item in the first index
        // Add items to the queue. Add new items as the first index (First in, First out);
        // Else, add all items as the last index
        public void EnqueueT(T item)
        {
            if (IsEmpty)
            {
                qList.AddFirst(item);
                return;
            }
            else
            {
                qList.AddLast(item);
            }
            
            LinkedListNode<T> existingItem = qList.First;
            while (existingItem != null && existingItem.Value.CompareTo(item) < 0)
            {
                existingItem = existingItem.Next;
            }
        }
        
        // Get the first item in the Queue
        // Delete the first item from the Queue. (First in, First Out);
        // return the new first item in the Queue after deletion
        public T Dequeue()
        {
            T value = qList.First.Value;
            qList.RemoveFirst();
            return value;
        }

        // Look at the first item in the Queue;
        public T Peek()
        {
            return qList.First.Value;
        }

        // The total Queue's that are left in the Queue;
        public int Count()
        {
            return qList.Count;
        }

        // Empty the list;
        public void Clear()
        {
            qList.Clear();
        }

        // Checks for items in the Queue. If it does - return TRUE | If it doesn't - return false;
        public bool Contains(T item)
        {
            return qList.Contains(item);
        }

        // Check for Empty list
        public bool IsEmpty
        {
            get { return qList.Count == 0; }
        }
    }

}