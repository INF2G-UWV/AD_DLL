using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    /// <summary>
    ///     ListNode class
    ///     Author: Ferdi Smit - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListNode<T>
    {
        /// <summary>
        ///     Constructor with item
        /// </summary>
        /// <param name="item"></param>
        public ListNode(T item)
        {
            Item = item;
            Next = null;
        }

        /// <summary>
        ///     Constructor with item and node
        /// </summary>
        /// <param name="item"></param>
        /// <param name="next"></param>
        public ListNode(T item, ListNode<T> next)
        {
            Item = item;
            Next = next;
        }

        /// <summary>
        ///     Holds the next ListNode
        /// </summary>
        public ListNode<T> Next { get; set; }

        /// <summary>
        ///     Holds value in current Node
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        ///     Overriding ToString to return a string value for the item in the node
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Item == null)
            {
                return string.Empty;
            }
            return Item.ToString();
        }
    }

    public class InsertBeforeHeaderException : ApplicationException
    {
        public InsertBeforeHeaderException(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    ///     SinglyLinkedList class, custom version of LinkedList
    ///     Author: Ferdi Smit - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T> : ICollection<T>
    {
        #region private variables

        private string strListName;

        #endregion

        /// <summary>
        ///     Constructor with provided listname
        /// </summary>
        /// <param name="strListName"></param>
        public SinglyLinkedList(string strListName)
        {
            this.strListName = strListName;
            Count = 0;
            FirstNode = LastNode = null;
        }

        /// <summary>
        ///     Constructor with default name "MyList"
        /// </summary>
        public SinglyLinkedList() : this("MyList")
        {
        }

        /// <summary>
        ///     Property to hold first node in the list
        /// </summary>
        public ListNode<T> FirstNode { get; private set; }

        /// <summary>
        ///     Property to hold last node in the list
        /// </summary>
        public ListNode<T> LastNode { get; private set; }

        /// <summary>
        ///     Indexer to iterate through the list and fetch the item
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
                var currentNode = FirstNode;
                for (var i = 0; i < index; i++)
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
        ///     Property to determine if the list is empty or contains any item
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                lock (this)
                {
                    return FirstNode == null;
                }
            }
        }

        /// <summary>
        ///     Property to hold count of items in the list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Removes the input if exists and returns true else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (FirstNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromFront();
                return true;
            }
            if (LastNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromBack();
                return true;
            }
            var currentNode = FirstNode;
            while (currentNode.Next != null)
            {
                if (currentNode.Next.Item.ToString().Equals(item.ToString()))
                {
                    currentNode.Next = currentNode.Next.Next;
                    Count--;
                    if (currentNode.Next == null)
                    {
                        LastNode = currentNode;
                    }
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        /// <summary>
        ///     Returns true if list contains the input item else false
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            lock (this)
            {
                var currentNode = FirstNode;
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
        ///     Operation resets the list and clears all its contents
        /// </summary>
        public void Clear()
        {
            FirstNode = LastNode = null;
            Count = 0;
        }

        #region IEnumarable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = FirstNode;
            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
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

            var node = FirstNode;
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

        /// <summary>
        ///     Operation ToString overridden to get the contents from the list
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsEmpty)
            {
                return string.Empty;
            }
            var returnString = new StringBuilder();
            foreach (var item in this)
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
        ///     Operation inserts item at the front of the list
        /// </summary>
        /// <param name="item"></param>
        public void InsertAtFront(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                {
                    FirstNode = LastNode = new ListNode<T>(item);
                }
                else
                {
                    FirstNode = new ListNode<T>(item, FirstNode);
                }
                Count++;
            }
        }

        /// <summary>
        ///     Operations inserts item at the back of the list
        /// </summary>
        /// <param name="item"></param>
        public void InsertAtBack(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                {
                    FirstNode = LastNode = new ListNode<T>(item);
                }
                else
                {
                    LastNode = LastNode.Next = new ListNode<T>(item);
                }
                Count++;
            }
        }

        /// <summary>
        ///     Operation removes item from the front of the list
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
                object removedData = FirstNode.Item;
                if (FirstNode == LastNode)
                {
                    FirstNode = LastNode = null;
                }
                else
                {
                    FirstNode = FirstNode.Next;
                }
                Count--;
                return removedData;
            }
        }

        /// <summary>
        ///     Operation removes item from the back of the list
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
                object removedData = LastNode.Item;
                if (FirstNode == LastNode)
                {
                    FirstNode = LastNode = null;
                }
                else
                {
                    var currentNode = FirstNode;
                    while (currentNode.Next != LastNode && currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }
                    LastNode = currentNode;
                    currentNode.Next = null;
                }
                Count--;
                return removedData;
            }
        }

        /// <summary>
        ///     Operation inserts item at the specified index in the list
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void InsertAt(int index, T item)
        {
            lock (this)
            {
                if (index > Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (index == 0)
                {
                    InsertAtFront(item);
                }
                else if (index == (Count - 1))
                {
                    InsertAtBack(item);
                }
                else
                {
                    var currentNode = FirstNode;
                    for (var i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    var newNode = new ListNode<T>(item, currentNode.Next);
                    currentNode.Next = newNode;
                    Count++;
                }
            }
        }

        /// <summary>
        ///     Operation removes item from the specified index in the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object RemoveAt(int index)
        {
            lock (this)
            {
                if (index > Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                object removedData;
                if (index == 0)
                {
                    removedData = RemoveFromFront();
                }
                else if (index == (Count - 1))
                {
                    removedData = RemoveFromBack();
                }
                else
                {
                    var currentNode = FirstNode;
                    for (var i = 1; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    removedData = currentNode.Item;
                    currentNode.Next = currentNode.Next.Next;
                    Count--;
                }
                return removedData;
            }
        }

        /// <summary>
        ///     Operation updates an item provided as an input with a new item
        ///     (also provided as an input)
        /// </summary>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public bool Update(T oldItem, T newItem)
        {
            lock (this)
            {
                var currentNode = FirstNode;
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

        public void ShowList()
        {
            var current = FirstNode;
            do
            {
                Console.WriteLine(current.Item);
                current = current.Next;
            } while (current != null);
        }

        /// <summary>
        ///     Operation to reverse the contents of the linked list
        ///     by resetting the pointers and swapping the contents
        /// </summary>
        public void Reverse()
        {
            if (FirstNode == null || FirstNode.Next == null)
            {
                return;
            }
            LastNode = FirstNode;
            ListNode<T> prevNode = null;
            var currentNode = FirstNode;
            var nextNode = FirstNode.Next;

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
            FirstNode = currentNode;
        }

        /// <summary>
        ///     Operation to find if the linked list contains a circular loop
        /// </summary>
        /// <returns></returns>
        public bool HasCycle()
        {
            var currentNode = FirstNode;
            var iteratorNode = FirstNode;
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
        ///     Operation to find the midpoint of a list
        /// </summary>
        /// <returns></returns>
        public ListNode<T> GetMiddleItem()
        {
            var currentNode = FirstNode;
            var iteratorNode = FirstNode;
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
            return FirstNode;
        }
    }
}