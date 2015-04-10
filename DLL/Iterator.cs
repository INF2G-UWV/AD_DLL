using System;

namespace DLL
{
    /// <summary>
    ///     IteratorNode.
    ///     To be used in the Iterator and LinkedList class.
    ///     Author: Ferdi Smit - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IteratorNode<T>
    {
        //Fields
        public T item;
        public IteratorNode<T> link;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="item">Item for Node</param>
        public IteratorNode(T item)
        {
            this.item = item;
            link = null;
        }

        /// <summary>
        ///     Empty constructor
        /// </summary>
        public IteratorNode()
        {
            link = null;
        }

        /// <summary>
        ///     Link value
        /// </summary>
        public IteratorNode<T> Link
        {
            get { return link; }
            set { link = value; }
        }

        /// <summary>
        ///     Item value
        /// </summary>
        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        /// <summary>
        ///     Custom ToString
        /// </summary>
        /// <returns>string - item</returns>
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
    ///     LinkedList class.
    ///     Author: Ferdi Smit && Marcel Schoeber - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
    {
        //fields
        private readonly IteratorNode<T> header;

        /// <summary>
        ///     Constructor with item as header
        /// </summary>
        /// <param name="item">item</param>
        public LinkedList(T item)
        {
            header = new IteratorNode<T>(item);
        }

        /// <summary>
        ///     Check if link is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return (header.Link == null);
        }

        /// <summary>
        ///     Find an item within the LinkedList
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>IteratorNode</returns>
        private IteratorNode<T> Find(T item)
        {
            // create new node
            var current = new IteratorNode<T>();

            //put header in current node
            current = header;

            //Put new item in current when available
            while (!current.Item.Equals(item))
            {
                current = current.Link;
            }

            return current;
        }

        /// <summary>
        ///     Insert an item after another item
        /// </summary>
        /// <param name="newItem">item to be inserted</param>
        /// <param name="after">previous item</param>
        public void Insert(T newItem, T after)
        {
            //create nodes
            var current = new IteratorNode<T>();
            var newNode = new IteratorNode<T>(newItem);

            //Put the previous node in current
            current = Find(after);

            //Link the nodes
            newNode.Link = current.Link;
            current.Link = newNode;
        }

        /// <summary>
        ///     Get first node
        /// </summary>
        /// <returns>IteratorNode</returns>
        public IteratorNode<T> GetFirst()
        {
            return header;
        }

        /// <summary>
        ///     Find the previous node
        /// </summary>
        /// <param name="n">item</param>
        /// <returns></returns>
        private IteratorNode<T> FindPrevious(T n)
        {
            var current = header;
            while (!(current.Link.Equals(null)) && (!current.Link.Item.Equals(n)))
            {
                current = current.Link;
            }
            return current;
        }

        /// <summary>
        ///     Remove an item
        /// </summary>
        /// <param name="n">item</param>
        public void Remove(T n)
        {
            var p = FindPrevious(n);
            if (!(p.Link.Equals(null)))
            {
                p.Link = p.Link.Link;
            }
        }

        /// <summary>
        ///     Show a list of all nodes
        /// </summary>
        public void ShowList()
        {
            var current = header.Link;
            while (current != null)
            {
                Console.WriteLine(current.Item);
                current = current.Link;
            }
        }
    }

    /// <summary>
    ///     Iterator class.
    ///     Cycles through items in a LinkedList.
    ///     Author: Ferdi Smit - INF2G.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Iterator<T>
    {
        //fields
        private readonly LinkedList<T> list;
        private IteratorNode<T> current;
        private IteratorNode<T> previous;

        /// <summary>
        ///     Constructor with LinkedList item
        /// </summary>
        /// <param name="list">LinkedList</param>
        public Iterator(LinkedList<T> list)
        {
            this.list = list;
            current = list.GetFirst();
            previous = null;
        }

        /// <summary>
        ///     Go to next link
        /// </summary>
        public void NextLink()
        {
            previous = current;
            current = current.Link;
        }

        /// <summary>
        ///     Get the current IteratorNode
        /// </summary>
        /// <returns></returns>
        public IteratorNode<T> GetCurrent()
        {
            return current;
        }

        /// <summary>
        ///     Insert before the current node
        /// </summary>
        /// <param name="item">item</param>
        public void InsertBefore(T item)
        {
            //new node
            var newNode = new IteratorNode<T>(item);

            //Exception if null
            if (previous.Link == null)
            {
                throw new InsertBeforeHeaderException("Can't insert here!");
            }

            //Link nodes
            newNode.Link = previous.Link;
            previous.Link = newNode;
            current = newNode;
        }

        /// <summary>
        ///     Insert after the current node
        /// </summary>
        /// <param name="item">item</param>
        public void InsertAfter(T item)
        {
            var newNode = new IteratorNode<T>(item) {Link = current.Link};
            current.Link = newNode;
            NextLink();
        }

        /// <summary>
        ///     Remove the previous node
        /// </summary>
        public void Remove()
        {
            previous.Link = current.Link;
        }

        /// <summary>
        ///     Reset Iterator
        /// </summary>
        public void Reset()
        {
            current = list.GetFirst();
            previous = null;
        }

        /// <summary>
        ///     Check if end is reached
        /// </summary>
        /// <returns>bool</returns>
        public bool AtEnd()
        {
            return (current.Link == null);
        }
    }
}