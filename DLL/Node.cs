namespace DLL
{
    public class Node<T>
    {
        public T item;
        public Node<T> next;
        public Node<T> previous;

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