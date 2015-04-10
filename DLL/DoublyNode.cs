using System;

namespace DLL
{
    /// <summary>
    ///     Doubly Node class.
    ///     Author: Marcel Schoeber - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DoublyNode<T>
    {
        public DoublyNode<T> Blink;
        public Object Element;
        public DoublyNode<T> Flink;

        /// <summary>
        ///     Constructor
        /// </summary>
        public DoublyNode()
        {
            Element = null;
            Flink = null;
            Blink = null;
        }

        /// <summary>
        ///     Constructor with item
        /// </summary>
        /// <param name="theElement">item</param>
        public DoublyNode(T theElement)
        {
            Element = theElement;
            Flink = null;
            Blink = null;
        }
    }
}