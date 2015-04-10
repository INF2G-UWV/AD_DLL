using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    /// <summary>
    ///     DoublyLinkedList
    ///     Author: INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoublyLinkedList<T> : ICollection<T>
    {
        private string listName;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="listName">name of list</param>
        public DoublyLinkedList(string listName)
        {
            this.listName = listName;
            Count = 0;
            FirstNode = LastNode = null;
        }

        /// <summary>
        ///     Constructor with default MyList name
        /// </summary>
        public DoublyLinkedList() : this("MyList")
        {
        }

        //Firstnode
        public Node<T> FirstNode { get; private set; }
        //Lastnode
        public Node<T> LastNode { get; private set; }

        /// <summary>
        ///     Check index
        /// </summary>
        /// <param name="index">index value</param>
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
        ///     Return number of items in list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Remove an item in the list
        /// </summary>
        /// <param name="item">generic item</param>
        /// <returns>removed true/false</returns>
        public bool Remove(T item)
        {
            //Item is first node
            if (FirstNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromFront();
                return true;
            }
            //If item is last node
            if (LastNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromBack();
                return true;
            }
            //Find the item
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
        ///     Check if list contains an item
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>exists true/false</returns>
        public bool Contains(T item)
        {
            lock (this)
            {
                //Search
                var currentNode = Find(item);
                //If not null
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
        /// <returns>IEnumerator</returns>
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
        /// <param name="array">array</param>
        /// <param name="arrayIndex">index value</param>
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

        /// <summary>
        ///     Check if readonly
        /// </summary>
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        ///     ToString override
        /// </summary>
        /// <returns>string</returns>
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
        ///     Find a node
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>Node</returns>
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
        ///     Insert node at front of list
        /// </summary>
        /// <param name="item">item</param>
        public void InsertAtFront(T item)
        {
            lock (this)
            {
                //If list is empty, add to current and last node
                if (IsEmpty)
                {
                    FirstNode = LastNode = new Node<T>(item);
                }
                else
                {
                    //Add to front
                    var node = new Node<T>(item, null, FirstNode);
                    FirstNode.Previous = node;
                    FirstNode = node;
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
            //If list is empty, add to firstnode and lastnode
            if (IsEmpty)
            {
                FirstNode = LastNode = new Node<T>(item);
            }
            else
            {
                //Add to back
                var node = new Node<T>(item, LastNode, null);
                LastNode.Next = node;
                LastNode = node;
            }
            //Increment count
            Count++;
        }

        /// <summary>
        ///     Remove from front of list
        /// </summary>
        /// <returns></returns>
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
                //If firstnode and last node are equal, nullify them
                if (FirstNode == LastNode)
                {
                    FirstNode = LastNode = null;
                }
                else
                {
                    //Remove node
                    FirstNode = FirstNode.Next;
                    FirstNode.Previous = null;
                }
                //Decrement count
                Count--;
                return removedData;
            }
        }

        /// <summary>
        ///     Remove item from back
        /// </summary>
        /// <returns></returns>
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
                //If firstnode and lastnode are equal, nullify them
                if (FirstNode == LastNode)
                {
                    FirstNode = LastNode = null;
                }
                else
                {
                    //Remove item
                    LastNode = LastNode.Previous;
                    LastNode.Next = null;
                }
                //Decrement count
                Count--;
                return removedData;
            }
        }

        /// <summary>
        ///     Insert at given index
        /// </summary>
        /// <param name="index">index value</param>
        /// <param name="item">item to be added</param>
        public void InsertAt(int index, T item)
        {
            lock (this)
            {
                //If out of bounds, throw exception
                if (index > Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                //If first index, insert at back
                if (index == 0)
                {
                    InsertAtBack(item);
                }
                //If last index, insert at front
                else if (index == (Count - 1))
                {
                    InsertAtFront(item);
                }
                else
                {
                    //Insert at index
                    var currentNode = FirstNode;
                    for (var i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    var newNode = new Node<T>(item, currentNode.Previous, currentNode);
                    currentNode.Previous = newNode;
                    Count++;
                }
            }
        }

        /// <summary>
        ///     Remove at index
        /// </summary>
        /// <param name="index">index value</param>
        /// <returns></returns>
        public object RemoveAt(int index)
        {
            lock (this)
            {
                //If index is out of bounds, trow exception
                if (index > Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                object removedData;
                //Remove from front when index is zero
                if (index == 0)
                {
                    removedData = RemoveFromFront();
                }
                //Remove from back when index is max value
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
                    Count--;
                }
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
                //If not null
                if (currentNode != null)
                {
                    //Set new item
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
            } while (currentNode != null);
        }
    }
}