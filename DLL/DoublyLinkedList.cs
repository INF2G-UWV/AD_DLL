using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        private string listName;
        public Node<T> FirstNode { get; private set; }
        public Node<T> LastNode { get; private set; }

        public DoublyLinkedList(string listName)
        {
            this.listName = listName;
            Count = 0;
            FirstNode = LastNode = null;
        }

        public DoublyLinkedList() : this("MyList")
        {
        }

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

        public int Count { get; private set; }

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
            var currentNode = Find(item);
            if (currentNode != null)
            {
                currentNode.Previous.Next = currentNode.Next;
                currentNode.Next.Previous = currentNode.Previous;
                return true;
            }
            return false;
        }

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

        public void Clear()
        {
            FirstNode = LastNode = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = FirstNode;
            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

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

        public void InsertAtFront(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                {
                    FirstNode = LastNode = new Node<T>(item);
                }
                else
                {
                    var node = new Node<T>(item, null, FirstNode);
                    FirstNode.Previous = node;
                    FirstNode = node;
                }
            }
        }

        public void InsertAtBack(T item)
        {
            if (IsEmpty)
            {
                FirstNode = LastNode = new Node<T>(item);
            }
            else
            {
                var node = new Node<T>(item, LastNode, null);
                LastNode.Next = node;
                LastNode = node;
            }
        }

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
                    FirstNode.Previous = null;
                }
                Count--;
                return removedData;
            }
        }

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
                    LastNode = LastNode.Previous;
                    LastNode.Next = null;
                }
                Count--;
                return removedData;
            }
        }

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
                    InsertAtBack(item);
                }
                else if (index == (Count - 1))
                {
                    InsertAtFront(item);
                }
                else
                {
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

        public bool Update(T oldItem, T newItem)
        {
            lock (this)
            {
                var currentNode = Find(oldItem);
                if (currentNode != null)
                {
                    currentNode.Item = newItem;
                    return true;
                }
                return false;
            }
        }

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