using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class ListNode<T>
    {
        private ListNode<T> next;
        private T item;

        /// <summary>
        /// Property to hold pointer to next ListNode - Self containing object
        /// </summary>
        public ListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        /// <summary>
        /// Property to hold value into the Node
        /// </summary>
        public T Item
        {
            get { return item; }
            set { item = value; }
        }


        /// <summary>
        /// Constructor with item init
        /// </summary>
        /// <param name="item"></param>
        public ListNode(T item)
        {
            this.item = item;
            next = null;
        }

        /// <summary>
        /// Constructor with item and the next node specified
        /// </summary>
        /// <param name="item"></param>
        /// <param name="next"></param>
        public ListNode(T item, ListNode<T> next)
        {
            this.item = item;
            this.next = next;
        }

        /// <summary>
        /// Overriding ToString to return a string value for the item in the node
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (item == null)
            {
                return string.Empty;
            }
            return item.ToString();
        }
    }

    public class InsertBeforeHeaderException : System.ApplicationException
    {
        public InsertBeforeHeaderException(string message)
            : base(message)
        {

        }
    }

    /// <summary>
    /// SinglyLinkedList class for generic implementation of LinkedList.
    /// Again, avoiding boxing unboxing here and using ICollection interface members.
    /// Believe this can be useful when applying other
    /// operations such as sorting, searching etc.
    /// </summary>
    public class SinglyLinkedList<T> : ICollection<T>
    {
        #region private variables

        private string strListName;
        private ListNode<T> firstNode;
        private ListNode<T> lastNode;
        private int count;

        #endregion

        /// <summary>
        /// Property to hold first node in the list
        /// </summary>
        public ListNode<T> FirstNode
        {
            get { return firstNode; }
        }

        /// <summary>
        /// Property to hold last node in the list
        /// </summary>
        public ListNode<T> LastNode
        {
            get { return lastNode; }
        }

        /// <summary>
        /// Indexer to iterate through the list and fetch the item
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                ListNode<T> currentNode = firstNode;
                for (int i = 0; i < index; i++)
                {
                    if (currentNode.Next == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    currentNode = currentNode.Next;
                }
                return currentNode.Item;
            }
        }

        /// <summary>
        /// Property to hold count of items in the list
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Property to determine if the list is empty or contains any item
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                lock (this)
                {
                    return firstNode == null;
                }
            }
        }

        /// <summary>
        /// Constructor initializing list with a provided list name
        /// </summary>
        /// <param name="strListName"></param>
        public SinglyLinkedList(string strListName)
        {
            this.strListName = strListName;
            count = 0;
            firstNode = lastNode = null;
        }

        /// <summary>
        /// Default constructor initialzing list with a default name "MyList"
        /// </summary>
        public SinglyLinkedList() : this("MyList") { }


        /// <summary>
        /// Operation ToString overridden to get the contents from the list
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsEmpty)
            {
                return string.Empty;
            }
            StringBuilder returnString = new StringBuilder();
            foreach (T item in this)
            {
                if (returnString.Length > 0)
                {
                    returnString.Append("->");
                }
                returnString.Append(item);
            }
            return returnString.ToString();
        }

        /// <summary>
        /// Operation inserts item at the front of the list
        /// </summary>
        /// <param name="item"></param>
        public void InsertAtFront(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                {
                    firstNode = lastNode = new ListNode<T>(item);
                }
                else
                {
                    firstNode = new ListNode<T>(item, firstNode);
                }
                count++;
            }
        }

        /// <summary>
        /// Operations inserts item at the back of the list
        /// </summary>
        /// <param name="item"></param>
        public void InsertAtBack(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                {
                    firstNode = lastNode = new ListNode<T>(item);
                }
                else
                {
                    lastNode = lastNode.Next = new ListNode<T>(item);
                }
            }
        }

        /// <summary>
        /// Operation removes item from the front of the list
        /// </summary>
        /// <returns></returns>
        public object RemoveFromFront()
        {
            lock (this)
            {
                if (IsEmpty)
                {
                    throw new ApplicationException("List is empty!");
                }
                object removedData = firstNode.Item;
                if (firstNode == lastNode)
                {
                    firstNode = lastNode = null;
                }
                else
                {
                    firstNode = firstNode.Next;
                }
                count--;
                return removedData;
            }
        }


        /// <summary>
        /// Operation removes item from the back of the list
        /// </summary>
        /// <returns></returns>
        public object RemoveFromBack()
        {
            lock (this)
            {
                if (IsEmpty)
                {
                    throw new ApplicationException("List is empty!");
                }
                object removedData = lastNode.Item;
                if (firstNode == lastNode)
                {
                    firstNode = lastNode = null;
                }
                else
                {
                    ListNode<T> currentNode = firstNode;
                    while (currentNode.Next != lastNode)
                    {
                        currentNode = currentNode.Next;
                    }
                    lastNode = currentNode;
                    currentNode.Next = null;
                }
                count--;
                return removedData;
            }
        }

        /// <summary>
        /// Operation inserts item at the specified index in the list
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void InsertAt(int index, T item)
        {
            lock (this)
            {
                if (index > count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (index == 0)
                {
                    InsertAtFront(item);
                }
                else if (index == (count - 1))
                {
                    InsertAtBack(item);
                }
                else
                {
                    ListNode<T> currentNode = firstNode;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    ListNode<T> newNode = new ListNode<T>(item, currentNode.Next);
                    currentNode.Next = newNode;
                    count++;
                }
            }
        }


        /// <summary>
        /// Operation removes item from the specified index in the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object RemoveAt(int index)
        {
            lock (this)
            {
                if (index > count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                object removedData;
                if (index == 0)
                {
                    removedData = RemoveFromFront();
                }
                else if (index == (count - 1))
                {
                    removedData = RemoveFromBack();
                }
                else
                {
                    ListNode<T> currentNode = firstNode;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    removedData = currentNode.Item;
                    currentNode.Next = currentNode.Next.Next;
                    count--;
                }
                return removedData;
            }
        }

        /// <summary>
        /// Removes the input if exists and returns true else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (firstNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromFront();
                return true;
            }
            else if (lastNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromBack();
                return true;
            }
            else
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode.Next != null)
                {
                    if (currentNode.Next.Item.ToString().Equals(item.ToString()))
                    {
                        currentNode.Next = currentNode.Next.Next;
                        count--;
                        if (currentNode.Next == null)
                        {
                            lastNode = currentNode;
                        }
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }

        /// <summary>
        /// Operation updates an item provided as an input with a new item
        /// (also provided as an input)
        /// </summary>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public bool Update(T oldItem, T newItem)
        {
            lock (this)
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode != null)
                {
                    if (currentNode.ToString().Equals(oldItem.ToString()))
                    {
                        currentNode.Item = newItem;
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
            }
        }

        /// <summary>
        /// Returns true if list contains the input item else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            lock (this)
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode != null)
                {
                    if (currentNode.Item.ToString().Equals(item.ToString()))
                    {
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
            }
        }

        /// <summary>
        /// Operation resets the list and clears all its contents
        /// </summary>
        public void Clear()
        {
            firstNode = lastNode = null;
            count = 0;
        }

        public void ShowList()
        {
            ListNode<T> current = firstNode;
            do
            {
                Console.WriteLine(current.Item);
                current = current.Next;
            } while (!(current == null));
        }

        /// <summary>
        /// Operation to reverse the contents of the linked list
        /// by resetting the pointers and swapping the contents
        /// </summary>
        public void Reverse()
        {
            if (firstNode == null || firstNode.Next == null)
            {
                return;
            }
            lastNode = firstNode;
            ListNode<T> prevNode = null;
            ListNode<T> currentNode = firstNode;
            ListNode<T> nextNode = firstNode.Next;

            while (currentNode != null)
            {
                currentNode.Next = prevNode;
                if (nextNode == null)
                {
                    break;
                }
                prevNode = currentNode;
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }
            firstNode = currentNode;
        }

        /// <summary>
        /// Operation to find if the linked list contains a circular loop
        /// </summary>
        /// <returns></returns>
        public bool HasCycle()
        {
            ListNode<T> currentNode = firstNode;
            ListNode<T> iteratorNode = firstNode;
            for (;
                iteratorNode != null && iteratorNode.Next != null;
                iteratorNode = iteratorNode.Next)
            {
                if (currentNode.Next == null || currentNode.Next.Next == null)
                {
                    return false;
                }
                if (currentNode.Next == iteratorNode || currentNode.Next.Next == iteratorNode)
                {
                    return true;
                }
                currentNode = currentNode.Next.Next;
            }
            return false;
        }

        /// <summary>
        /// Operation to find the midpoint of a list
        /// </summary>
        /// <returns></returns>
        public ListNode<T> GetMiddleItem()
        {
            ListNode<T> currentNode = firstNode;
            ListNode<T> iteratorNode = firstNode;
            for (;
                iteratorNode != null && iteratorNode.Next != null;
                iteratorNode = iteratorNode.Next)
            {
                if (currentNode.Next == null || currentNode.Next.Next == null)
                {
                    return iteratorNode;
                }
                if (currentNode.Next == iteratorNode || currentNode.Next.Next == iteratorNode)
                {
                    return null;
                }
                currentNode = currentNode.Next.Next;
            }
            return firstNode;
        }

        #region IEnumarable<T> Members

        public IEnumerator<T> GetEnumerator() 
        {
            ListNode<T> currentNode = firstNode;
            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
        void ICollection<T>.Add(T item)
        {
            InsertAtBack(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Empty Array");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException("Buiten de array index");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }

            ListNode<T> node = firstNode;
            if (node != null)
            {
                do
                {
                    array[arrayIndex++] = node.Item;
                    node = node.Next;
                } while (node != null);
            }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        
    }
}
