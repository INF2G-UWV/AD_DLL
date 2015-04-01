using System;
using System.Collections.Generic;
using System.Linq;

namespace DLL
{
    /// <summary>
    ///     Priority Queue Class | Lowest number is Highest Priority
    ///     Chapter 5
    /// </summary>
    public class PQueue<T> where T : IComparable<T>
    {
        // Make a List to store all the items in it;
        private readonly SinglyLinkedList<T> qList;
        private readonly SinglyLinkedList<int> qPriority;

        public PQueue()
        {
            qList = new SinglyLinkedList<T>();
            qPriority = new SinglyLinkedList<int>();
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
        ///     Add the Item and the priority to the list;
        /// </summary>
        /// <param name="item">The Item that will be inserted (T)</param>
        /// <param name="priority">The priority that will be inserted (int)</param>
        public void Enqueue(T item, int priority)
        {
            if (IsEmpty)
            {
                qList.InsertAtFront(item);
                qPriority.InsertAtFront(priority);
            }
            qList.InsertAtBack(item);
            qPriority.InsertAtBack(priority);
        }

        /// <summary>
        ///     It removes (Dequeues) the Highest Priority Item in the Queue.
        /// </summary>
        /// <returns>Returns the new first Item in the Queue after deletion (temp var)</returns>
        public T Dequeue()
        {
            var value = default(T);
            //T prior = default(T);

            if (!IsEmpty)
            {
                var index = 0;
                var topPriority = qPriority[0];

                // Loops through the list
                for (var i = 1; i < qPriority.Count; i++)
                {
                    // IComparable | Compares the first Priority in the list with the 
                    // Priorities that has been looped through | > 0 checks for the lowest number (highest priority)
                    if (topPriority.CompareTo(qPriority[i]) > 0)
                    {
                        // Saves the highest priority in the var index
                        topPriority = qPriority[i];
                        index = i;
                    }
                }
                value = qList[index];
                //prior = topPriority;

                Console.Write("Dequeueing the highest Priority item in the Queue: ");
                qList.RemoveAt(index);
                qPriority.RemoveAt(index);
            }
            else
            {
                Console.Write("There are no items to Dequeue");
            }
            return value;
        }

        /// <summary>
        ///     Checks for items that are already in the Queue;
        /// </summary>
        /// <param name="item">Look for the givin item in the list</param>
        /// <returns>Item is found in the index; | Item is not found in the index</returns>
        public void Contains(T item)
        {
            if (!IsEmpty)
            {
                Console.Write(qList.Contains(item) ? "Item is found in the index" : "Item is not found in the index");
            }
            else
            {
                Console.Write("There are no items to Search through");
            }
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
        ///     Displays all items in the Queue. Loops through
        ///     2 lists to show the Items + Priority stored in the list;
        /// </summary>
        public void GetAllQueueItems()
        {
            if (!IsEmpty)
            {
                // 2 foreach loops in 1, qList & qPriority
                var loop = qList.Zip(qPriority, (first, second) => first + "_Priority = " + second);
                Console.WriteLine("Items in the Queue: ");
                foreach (var item in loop)
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