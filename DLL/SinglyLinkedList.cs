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

        public void InsertAtFrond(T item)
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

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
