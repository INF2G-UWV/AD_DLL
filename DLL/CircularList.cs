using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    /// <summary>
    ///     CircularList.
    ///     Author: INF2G.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularList<T> : ICollection<T>
    {
        private string listName;

        /// <summary>
        ///     Constructor with list name
        /// </summary>
        /// <param name="listName">listname</param>
        public CircularList(string listName)
        {
            this.listName = listName;
            Count = 0;
            FirstNode = LastNode = null;
        }

        /// <summary>
        ///     Constructor with default listname MyList
        /// </summary>
        public CircularList() : this("MyList")
        {
        }

        //nodes
        public Node<T> FirstNode { get; private set; }
        public Node<T> LastNode { get; private set; }

        /// <summary>
        ///     Check index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>item</returns>
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
        ///     Check if list is empty
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
        ///     Count number of items in list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Remove item from list
        /// </summary>
        /// <param name="item">generic item</param>
        /// <returns>succesful true/false</returns>
        public bool Remove(T item)
        {
            //If node at front
            if (FirstNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromFront();
                return true;
            }
            //If node at back
            if (LastNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromBack();
                return true;
            }
            //Find node
            var currentNode = Find(item);
            //If not null
            if (currentNode != null)
            {
                //Remove
                currentNode.Previous.Next = currentNode.Next;
                currentNode.Next.Previous = currentNode.Previous;
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Check if list contains item
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>exists true/false</returns>
        public bool Contains(T item)
        {
            lock (this)
            {
                var currentNode = Find(item);
                if (currentNode != null)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///     Clear the list
        /// </summary>
        public void Clear()
        {
            FirstNode = LastNode = null;
            Count = 0;
        }

        /// <summary>
        ///     GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = FirstNode;
            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        ///     GetEnumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Add to collection
        /// </summary>
        /// <param name="item">item</param>
        void ICollection<T>.Add(T item)
        {
            InsertAtBack(item);
        }

        /// <summary>
        ///     Copy to different index in array
        /// </summary>
        /// <param name="array">generic array</param>
        /// <param name="arrayIndex">index</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            //If array is empty
            if (array == null)
            {
                throw new ArgumentNullException("Empty Array");
            }
            //If out of bounds
            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException("Out of bounds");
            }
            //If negative
            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException();
            }
            var node = FirstNode;
            //If not null
            if (node != null)
            {
                do
                {
                    //Copy
                    array[arrayIndex++] = node.Item;
                    node = node.Next;
                } while (node != null);
            }
        }

        /// <summary>
        ///     Check if is readonly
        /// </summary>
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        ///     Convert to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            //Check if empty
            if (IsEmpty)
            {
                return string.Empty;
            }
            //Build string
            var returnString = new StringBuilder();
            //Add data
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
        ///     Find an item
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>node</returns>
        public Node<T> Find(T item)
        {
            lock (this)
            {
                var currentNode = FirstNode;
                while (currentNode != null)
                {
                    if (currentNode.Item.ToString().Equals(item.ToString()))
                    {
                        return currentNode;
                    }
                    currentNode = currentNode.Next;
                }
                return null;
            }
        }

        /// <summary>
        ///     Insert at front of list
        /// </summary>
        /// <param name="item">item</param>
        public void InsertAtFront(T item)
        {
            lock (this)
            {
                //If list is empty, create new node
                if (IsEmpty)
                {
                    FirstNode = LastNode = new Node<T>(item);
                    FirstNode.Previous = LastNode;
                    LastNode.Next = FirstNode;
                }
                else
                {
                    //Insert at front
                    var node = new Node<T>(item, LastNode, FirstNode);
                    FirstNode.Previous = node;
                    FirstNode = node;
                    LastNode.Next = FirstNode;
                }
            }
            //Increment count
            Count++;
        }

        /// <summary>
        ///     Insert at back of list
        /// </summary>
        /// <param name="item">item</param>
        public void InsertAtBack(T item)
        {
            //If list is empty create new node
            if (IsEmpty)
            {
                FirstNode = LastNode = new Node<T>(item);
                FirstNode.Previous = LastNode;
                LastNode.Next = FirstNode;
            }
            else
            {
                //Insert at back
                var node = new Node<T>(item, LastNode, FirstNode);
                LastNode.Next = node;
                LastNode = node;
                FirstNode.Previous = LastNode;
            }
            //Increment count
            Count++;
        }

        /// <summary>
        ///     Remove from front of list
        /// </summary>
        /// <returns>removed item</returns>
        public object RemoveFromFront()
        {
            lock (this)
            {
                //If list is empty, throw exception
                if (IsEmpty)
                {
                    throw new ApplicationException("List is empty!");
                }
                object removedData = FirstNode.Item;
                //If only one node exists, nullify
                if (FirstNode == LastNode)
                {
                    FirstNode = LastNode = null;
                }
                else
                {
                    //Remove
                    FirstNode = FirstNode.Next;
                    FirstNode.Previous = LastNode;
                }
                //Decrement count
                Count--;
                //Return the removed data
                return removedData;
            }
        }

        /// <summary>
        ///     Remove from back of list
        /// </summary>
        /// <returns>removed item</returns>
        public object RemoveFromBack()
        {
            lock (this)
            {
                //If list is empty, throw exception
                if (IsEmpty)
                {
                    throw new ApplicationException("List is empty!");
                }
                object removedData = LastNode.Item;
                //If only one node exists, nullify
                if (FirstNode == LastNode)
                {
                    FirstNode = LastNode = null;
                }
                else
                {
                    //Remove
                    LastNode = LastNode.Previous;
                    LastNode.Next = FirstNode;
                }
                //Decrement count
                Count--;
                //Return removed item
                return removedData;
            }
        }

        /// <summary>
        ///     Insert at given index
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="item">item</param>
        public void InsertAt(int index, T item)
        {
            lock (this)
            {
                //If out of bounds, throw exception
                if (index > Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                //If index is zero, insert at back
                if (index == 0)
                {
                    InsertAtBack(item);
                }
                //If index is max value, insert at front
                else if (index == (Count - 1))
                {
                    InsertAtFront(item);
                }
                else
                {
                    //Insert item
                    var currentNode = FirstNode;
                    for (var i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    var newNode = new Node<T>(item, currentNode.Previous, currentNode);
                    currentNode.Previous = newNode;
                    //Increment count
                    Count++;
                }
            }
        }

        /// <summary>
        ///     Remove at given index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>Removed item</returns>
        public object RemoveAt(int index)
        {
            lock (this)
            {
                //If out of bounds, throw exception
                if (index > Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                object removedData;
                //If index is zero, remove from front
                if (index == 0)
                {
                    removedData = RemoveFromFront();
                }
                //If index is max value, remove from back
                else if (index == (Count - 1))
                {
                    removedData = RemoveFromBack();
                }
                else
                {
                    //Remove
                    var currentNode = FirstNode;
                    for (var i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    removedData = currentNode.Item;
                    currentNode.Previous.Next = currentNode.Next;
                    //Decrement count
                    Count--;
                }
                //Return removed item
                return removedData;
            }
        }

        /// <summary>
        ///     Update old item with new item
        /// </summary>
        /// <param name="oldItem">old item</param>
        /// <param name="newItem">new item</param>
        /// <returns>succesful true/false</returns>
        public bool Update(T oldItem, T newItem)
        {
            lock (this)
            {
                //Find old item
                var currentNode = Find(oldItem);
                //Check if not null
                if (currentNode != null)
                {
                    //Replace with new item
                    currentNode.Item = newItem;
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///     Print the whole list
        /// </summary>
        public void ShowList()
        {
            var currentNode = FirstNode;
            do
            {
                Console.WriteLine(currentNode.Item);
                currentNode = currentNode.Next;
            } while (currentNode != FirstNode);
        }
    }
}