using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Chapter12
{
    /// <summary>
    /// Custom binary tree node
    /// </summary>
    /// <typeparam name="T">Specifies a generic type for the values</typeparam>
    public class BtNode<T> where T : IComparable<T>
    {
        //Value of a node
        protected T value;

        //Parent node
        protected BtNode<T> parent;

        //Left child of the node
        protected BtNode<T> leftChild;

        //Right child of the node
        protected BtNode<T> rightChild;

        /// <summary>
        /// Constructor of the binary tree node check its null
        /// </summary>
        /// <param name="value">It expects an generic type of value</param>
        public BtNode(T value)
        {
            if (value == null)
            {
                //Null value are not allowed in the BST
                throw new ArgumentNullException("Null values are not allowed in de Binary Search Tree");
            }

            this.value = value;
            this.parent = null;
            this.leftChild = null;
            this.rightChild = null;
        }

        //Methods

        /// <summary>
        /// Override the ToString method
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.value.ToString();
        }

        /// <summary>
        /// Override the gethashcode
        /// </summary>
        /// <returns>integers</returns>
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        /// <summary>
        /// Override the equals method
        /// </summary>
        /// <param name="obj">Could be anything</param>
        /// <returns>Equals using IComparable</returns>
        public override bool Equals(object obj)
        {
            BtNode<T> other = (BtNode<T>)obj;
            return this.CompareTo(other) == 0;
        }

        /// <summary>
        /// Customm CompareTo method
        /// </summary>
        /// <param name="other">A node comparing to another node</param>
        /// <returns>integer</returns>
        public int CompareTo(BtNode<T> other)
        {
            return this.value.CompareTo(other.value);
        }

        /// <summary>
        /// Inserts node in the binary search tree by given value
        /// </summary>
        /// <param name="value">the new value</param>
        /// <param name="parentNode">the parent of the new node</param>
        /// <param name="node">current node</param>
        /// <returns>the inserted node</returns>
        public BtNode<T> Insert(T value,
                BtNode<T> parentNode, BtNode<T> node)
        {
            if (node == null)
            {
                node = new BtNode<T>(value);
                node.parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.value);
                if (compareTo < 0)
                {
                    node.leftChild =
                        Insert(value, node, node.leftChild);
                }
                else if (compareTo > 0)
                {
                    node.rightChild =
                        Insert(value, node, node.rightChild);
                }
            }

            return node;
        }

        /// <summary>Finds a given value in the tree and
        /// return the node which contains it if such exsists
        /// </summary>
        /// <param name="value">the value to be found</param>
        /// <returns>the found node or null if not found</returns>
        public BtNode<T> Find(T value, BtNode<T> root)
        {
            BtNode<T> node = root;
            while (node != null)
            {
                int compareTo = value.CompareTo(node.value);
                if (compareTo < 0)
                {
                    node = node.leftChild;
                }
                else if (compareTo > 0)
                {
                    node = node.rightChild;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        /// <summary>Traverses and prints the ordered binary search tree
        /// tree starting from given root node.</summary>
        /// <param name="node">the starting node</param>
        public void PrintTreeDFS(BtNode<T> node)
        {
            if (node != null)
            {
                PrintTreeDFS(node.leftChild);
                Console.Write(node.value + " ");
                PrintTreeDFS(node.rightChild);
            }
        }

    }
}
