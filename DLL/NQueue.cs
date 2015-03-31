using System;
using System.Linq;

namespace DLL
{
    /// <summary>
    ///     NQueue Class
    ///     Chapter 5
    /// </summary>
    public class NQueue<T> where T : IComparable<T>
    {
        // Make a List to store all the items in it;
        private readonly SinglyLinkedList<T> qList;

        public NQueue()
        {
            qList = new SinglyLinkedList<T>();
        }

        /// <summary>
        ///     Check for empty list;
        /// </summary>
        /// <returns>true or false</returns>
        public bool IsEmpty
        {
            get { return qList.Count == 0; }
        }

        /// <summary>
        ///     When the list is still empty, Add (Enqueue) new item as first in the Queue,
        ///     else add it at the back of the Queue;
        /// </summary>
        /// <param name="item">The value that will be inserted (T)</param>
        public void Enqueue(T item)
        {
            if (IsEmpty)
            {
                qList.InsertAtBack(item);
                return;
            }
            qList.InsertAtBack(item);
        }

        /// <summary>
        ///     Stores the first item in the Queue in a temp variable;
        ///     It removes (Dequeues) the first item in the Queue: First in, First Out.
        /// </summary>
        /// <returns>Returns the new first items in the Queue after deletion (temp var)</returns>
        public T Dequeue()
        {
            var temp = default(T);
            if (!IsEmpty)
            {
                temp = qList.First();
                Console.Write("Dequeueing the first item in the Queue: ");
                qList.RemoveFromFront();
            }
            else
            {
                Console.Write("There are no items to Dequeue");
            }
            return temp;
        }

        /// <summary>
        ///     Stores the first item in the Queue in a temp variable;
        /// </summary>
        /// <returns>The first item in the Queue</returns>
        public T Peek()
        {
            var temp = default(T);
            if (!IsEmpty)
            {
                Console.Write("Peek at the first item in the Queue: ");
                temp = qList.First();
            }
            else
            {
                Console.Write("There are no items to Peek at");
            }
            return temp;
        }

        /// <summary>
        ///     Returns the total items in the Queue in numbers;
        /// </summary>
        public int Count()
        {
            return qList.Count;
        }

        /// <summary>
        ///     Clears the list. Removes all the items in the Queue;
        /// </summary>
        public void Clear()
        {
            Console.Write("The Queue list has been cleared! ");
            qList.Clear();
            Console.Write(qList.Count() + " item(s) remain in the list");
        }

        /// <summary>
        ///     Checks for items that are already in the Queue;
        /// </summary>
        /// <param name="item">Look for the givin value in the list</param>
        /// <returns>Item is found in the index; | Item is not found in the index</returns>
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
        ///     Displays all items in the Queue;
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