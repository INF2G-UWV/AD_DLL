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

        /// <summary>
        /// When the list is still empty, Add (Enqueue) new item as first in the Queue,
        /// else add it at the back of the Queue;
        /// 
        /// Creata a LinkedListNode that has the first item in the list (Queue),
        /// while the items exists (compareTo : IComparable) get the Node
        /// to the next in Queue;
        /// </summary>
        public void Enqueue(T item)
        {
            if (IsEmpty)
            {
                qList.AddFirst(item);
                return;
            }
            qList.AddLast(item);

            LinkedListNode<T> existingItem = qList.First;
            while (existingItem != null && existingItem.Value.CompareTo(item) < 0)
            {
                existingItem = existingItem.Next;
            }
        }

        /// <summary>
        /// It removes (Dequeues) the first item in the Queue: First in, First Out.
        /// Returns the new first items in the Queue after deletion with the 
        /// temp variable;
        /// </summary>
        public T Dequeue()
        {
            T temp = default(T);
            if (!IsEmpty)
            {
                temp = qList.First.Value;
                Console.Write("Dequeueing the first item in the Queue: ");
                qList.RemoveFirst();
            }
            else
            {
                Console.Write("There are no items to Dequeue");
            }
            return temp;
        }

        /// <summary>
        /// Stores the first item in the Queue in a temp variable
        /// and returns it if the Queue is not empty;
        /// </summary>
        public T Peek()
        {
            T temp = default(T);
            if (!IsEmpty)
            {
                Console.Write("Peek at the first item in the Queue: ");
                temp = qList.First.Value;
            }
            else
            {
                Console.Write("There are no items to Peek at");
            }
            return temp;
        }

        /// <summary>
        /// Returns the total items in the Queue in numbers;
        /// </summary>
        public int Count()
        {
            return qList.Count;
        }

        /// <summary>
        /// Clears the list. Removes all the items in the Queue;
        /// </summary>
        public void Clear()
        {
            Console.Write("The Queue list has been cleared! ");
            qList.Clear();
            Console.Write(qList.Count() + " item(s) remain in the list");
        }


        /// <summary>
        /// Checks for items that are already in the Queue. 
        /// If it finds one - returns Item is found in the index; | If it doesn't - returns Item is not found in the index";
        /// </summary>

        public void Contains(T item)
        {
            if (!IsEmpty)
            {
                Console.Write(qList.Contains(item) ? "Item is found in the index" : "Item is not found in the index");
                qList.Contains(item);
            }
            else
            {
                Console.Write("There are no items to Search through");
            }
        }


        /// <summary>
        /// Check for Empty list;
        /// </summary>
        public bool IsEmpty
        {
            get { return qList.Count == 0; }
        }

        /// <summary>
        /// Displays all items in the Queue;
        /// </summary>
        public void GetAllQueueItems()
        {
            if (!IsEmpty)
            {
                Console.WriteLine("Items in the Queue: ");
                foreach (var item in qList)
                {
                    Console.Write(item + ", ");
                }
            }
            else
            {
                Console.Write("There are no items to display");
            }
        }
    }

}