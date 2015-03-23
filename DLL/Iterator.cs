using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class IteratorNode<T>
    {
        public IteratorNode<T> link;
        public T item;

        public IteratorNode<T> Link
        {
            get { return link; }
            set { link = value; }
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        public IteratorNode(T item)
        {
            this.item = item;
            link = null;
        }

        public override string ToString()
        {
            if (item == null)
            {
                return string.Empty;
            }
            return item.ToString();
        }
    }

    public class LinkedList<T>
    {
        private IteratorNode<T> header;

        public LinkedList(T item)
        {
            header = new IteratorNode<T>(item);
        }

        public bool IsEmpty()
        {
            return (header.Link == null);
        }

        public IteratorNode<T> GetFirst()
        {
            return header;
        }

        public void ShowList()
        {
            IteratorNode<T> current = header.Link;
            while (!(current == null))
            {
                Console.WriteLine(current.Item);
                current = current.Link;
            }
        }
    }

    public class Iterator<T>
    {
        private IteratorNode<T> current;
        private IteratorNode<T> previous;
        private LinkedList<T> list;

        public Iterator(LinkedList<T> list)
        {
            this.list = list;
            current = list.GetFirst();
            previous = null;
        }

        public void NextLink()
        {
            previous = current;
            current = current.Link;
        }

        public IteratorNode<T> GetCurrent()
        {
            return current;
        }

        public void InsertBefore(T item)
        {
            IteratorNode<T> newNode = new IteratorNode<T>(item);
            if (previous.Link == null)
            {
                throw new InsertBeforeHeaderException("Can't insert here!");
            }
            else
            {
                newNode.Link = previous.Link;
                previous.Link = newNode;
                current = newNode;
            }
        }

        public void InsertAfter(T item)
        {
            IteratorNode<T> newNode = new IteratorNode<T>(item);
            newNode.Link = current.Link;
            current.Link = newNode;
            NextLink();
        }

        public void Remove()
        {
            previous.Link = current.Link;
        }

        public void Reset()
        {
            current = list.GetFirst();
            previous = null;
        }

        public bool AtEnd()
        {
            return (current.Link == null);
        }
    }
}
