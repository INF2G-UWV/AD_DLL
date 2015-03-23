using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class CircularList<T> : ICollection<T>
    {
        private string listName;
        private Node<T> firstNode;
        private Node<T> lastNode;
        private int count;

        public Node<T> FirstNode
        {
            get { return firstNode; }
        }

        public Node<T> LastNode
        {
            get { return lastNode; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Node<T> currentNode = firstNode;
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

        public int Count
        {
            get { return count; }
        }

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

        public CircularList(string listName)
        {
            this.listName = listName;
            count = 0;
            firstNode = lastNode = null;
        }

        public CircularList() : this("MyList") { }

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

        public Node<T> Find(T item)
        {
            lock (this)
            {
                Node<T> currentNode = firstNode;
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
                    firstNode = lastNode = new Node<T>(item);
                    firstNode.Previous = lastNode;
                    lastNode.Next = firstNode;
                }
                else
                {
                    Node<T> node = new Node<T>(item, lastNode, firstNode);
                    firstNode.Previous = node;
                    firstNode = node;
                    lastNode.Next = firstNode;
                }
            }
        }

        public void InsertAtBack(T item)
        {
            if (IsEmpty)
            {
                firstNode = lastNode = new Node<T>(item);
                firstNode.Previous = lastNode;
                lastNode.Next = firstNode;
            }
            else
            {
                Node<T> node = new Node<T>(item, lastNode, firstNode);
                lastNode.Next = node;
                lastNode = node;
                firstNode.Previous = lastNode;
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
                object removedData = firstNode.Item;
                if (firstNode == lastNode)
                {
                    firstNode = lastNode = null;
                }
                else
                {
                    firstNode = firstNode.Next;
                    firstNode.Previous = lastNode;
                }
                count--;
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
                object removedData = lastNode.Item;
                if (firstNode == lastNode)
                {
                    firstNode = lastNode = null;
                }
                else
                {
                    lastNode = lastNode.Previous;
                    lastNode.Next = firstNode;
                }
                count--;
                return removedData;
            }
        }

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
                    InsertAtBack(item);
                }
                else if (index == (count - 1))
                {
                    InsertAtFront(item);
                }
                else
                {
                    Node<T> currentNode = firstNode;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    Node<T> newNode = new Node<T>(item, currentNode.Previous, currentNode);
                    currentNode.Previous = newNode;
                    count++;
                }
            }
        }

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
                    Node<T> currentNode = firstNode;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    removedData = currentNode.Item;
                    currentNode.Previous.Next = currentNode.Next;
                    count--;
                }
                return removedData;
            }
        }

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
                Node<T> currentNode = Find(item);
                if (currentNode != null)
                {
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    return true;
                }
            }
            return false;
        }

        public bool Update(T oldItem, T newItem)
        {
            lock (this)
            {
                Node<T> currentNode = Find(oldItem);
                if (currentNode != null)
                {
                    currentNode.Item = newItem;
                    return true;
                }
                return false;
            }
        }

        public bool Contains(T item)
        {
            lock (this)
            {
                Node<T> currentNode = Find(item);
                if (currentNode != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void Clear()
        {
            firstNode = lastNode = null;
            count = 0;
        }

        public void ShowList()
        {
            Node<T> currentNode = firstNode;
            do
            {
                Console.WriteLine(currentNode.Item);
                currentNode = currentNode.Next;
            } while (!(currentNode == firstNode));
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = firstNode;
            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
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

            Node<T> node = firstNode;
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
