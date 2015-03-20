using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    /// <summary>
    ///     Priority Queue Class
    ///     Chapter 5
    /// </summary>
    public class PQueue<T> where T : IComparable<T>
    {
        // Make a List to store all the items in it;
        private List<T> qList;
        private List<T> qPriority;

        public PQueue()
        {
            qList = new List<T>();
            qPriority = new List<T>();
        }

        /// <summary>
        /// Adds value and priority to the Queue
        /// </summary>
        public void Enqueue(T value, T priority)
        {
            qList.Add(value);
            qPriority.Add(priority);   
        }

        public T Dequeue()
        {
            T value = default(T);
            T prior = default(T);

            if (!IsEmpty)
            {
                int index = 0;
                T topPriority = qPriority[0];

                for (int i = 1; i < qPriority.Count; i++)
                {
                    if (topPriority.CompareTo(qPriority[i]) > 0)
                    {
                        topPriority = qPriority[i];
                        index = i;
                    }
                }
                value = qList[index];
                prior = topPriority;

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
        /// Stores the first item in the Queue in a temp variable
        /// and returns it if the Queue is not empty;
        /// </summary>
        public T Peek()
        {
            T temp = default(T);
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

        /// <summary>
        /// Check for Empty list;
        /// </summary>
        public bool IsEmpty
        {
            get { return qList.Count == 0; }
        }
    }
}
