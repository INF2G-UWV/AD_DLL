namespace DLL
{
    /// <summary>
    ///     Basic Node
    ///     Author: Ferdi Smit - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        //fields
        public T item;
        public Node<T> next;
        public Node<T> previous;

        /// <summary>
        ///     Constructor with item
        /// </summary>
        /// <param name="item">item</param>
        public Node(T item)
        {
            this.item = item;
            previous = null;
            next = null;
        }

        /// <summary>
        ///     Constructor with multiple items
        /// </summary>
        /// <param name="item">item</param>
        /// <param name="previous">previous</param>
        /// <param name="next">next</param>
        public Node(T item, Node<T> previous, Node<T> next)
        {
            this.item = item;
            this.previous = previous;
            this.next = next;
        }

        /// <summary>
        ///     Get/Set previous
        /// </summary>
        public Node<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        /// <summary>
        ///     Get/Set next
        /// </summary>
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        /// <summary>
        ///     Get/Set item
        /// </summary>
        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        /// <summary>
        ///     Custom ToString method
        /// </summary>
        /// <returns>string representation of item</returns>
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