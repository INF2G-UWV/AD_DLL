using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Node<T>
    {
        public Node<T> previous;
        public Node<T> next;
        public T item;

        public Node<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        public Node(T item)
        {
            this.item = item;
            previous = null;
            next = null;
        }

        public Node(T item, Node<T> previous, Node<T> next)
        {
            this.item = item;
            this.previous = previous;
            this.next = next;
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
}
