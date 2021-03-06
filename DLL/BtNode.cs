﻿using System;

namespace DLL
{
    /// <summary>
    ///     Custom binary tree node
    ///     Author: INF2G
    /// </summary>
    /// <typeparam name="T">Specifies a generic type for the values</typeparam>
    public class BtNode<T> where T : IComparable<T>
    {
        //Left child of the node
        protected BtNode<T> leftChild;
        //Parent node
        protected BtNode<T> parent;
        //Right child of the node
        protected BtNode<T> rightChild;
        //Value of a node
        protected T value;

        /// <summary>
        ///     Constructor of the binary tree node check its null
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
            parent = null;
            leftChild = null;
            rightChild = null;
        }

        public BtNode()
        {
            if (value == null)
            {
                //Null value are not allowed in the BST
                throw new ArgumentNullException("Null values are not allowed in de Binary Search Tree");
            }
        }

        //Methods

        /// <summary>
        ///     Override the ToString method
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return value.ToString();
        }

        /// <summary>
        ///     Override the gethashcode
        /// </summary>
        /// <returns>integers</returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        ///     Override the equals method
        /// </summary>
        /// <param name="obj">Could be anything</param>
        /// <returns>Equals using IComparable</returns>
        public override bool Equals(object obj)
        {
            var other = (BtNode<T>) obj;
            return CompareTo(other) == 0;
        }

        /// <summary>
        ///     Customm CompareTo method
        /// </summary>
        /// <param name="other">A node comparing to another node</param>
        /// <returns>integer</returns>
        public int CompareTo(BtNode<T> other)
        {
            return value.CompareTo(other.value);
        }

        /// <summary>
        ///     Inserts node in the binary search tree by given value
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
                var compareTo = value.CompareTo(node.value);
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

        /// <summary>
        ///     Finds a given value in the tree and
        ///     return the node which contains it if such exsists
        /// </summary>
        /// <param name="value">the value to be found</param>
        /// <returns>the found node or null if not found</returns>
        public BtNode<T> Find(T value, BtNode<T> root)
        {
            var node = root;
            while (node != null)
            {
                var compareTo = value.CompareTo(node.value);
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

        /// <summary>
        ///     Remove node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="root"></param>
        public void Remove(BtNode<T> node, BtNode<T> root)
        {
            // Case 3: If the node has two children.
            // Note that if we get here at the end
            // the node will be with at most one child
            if (node.leftChild != null && node.rightChild != null)
            {
                var replacement = node.rightChild;
                while (replacement.leftChild != null)
                {
                    replacement = replacement.leftChild;
                }
                node.value = replacement.value;
                node = replacement;
            }

            // Case 1 and 2: If the node has at most one child
            var theChild = node.leftChild != null
                ? node.leftChild
                : node.rightChild;

            // If the element to be deleted has one child
            if (theChild != null)
            {
                theChild.parent = node.parent;

                // Handle the case when the element is the root
                if (node.parent == null)
                {
                    root = theChild;
                }
                else
                {
                    // Replace the element with its child sub-tree
                    if (node.parent.leftChild == node)
                    {
                        node.parent.leftChild = theChild;
                    }
                    else
                    {
                        node.parent.rightChild = theChild;
                    }
                }
            }
            else
            {
                // Handle the case when the element is the root
                if (node.parent == null)
                {
                    root = null;
                }
                else
                {
                    // Remove the element - it is a leaf
                    if (node.parent.leftChild == node)
                    {
                        node.parent.leftChild = null;
                    }
                    else
                    {
                        node.parent.rightChild = null;
                    }
                }
            }
        }

        /// <summary>
        ///     Traverses and prints the ordered binary search tree
        ///     tree starting from given root node.
        /// </summary>
        /// <param name="node">the starting node</param>
        public void PrintTree(BtNode<T> node)
        {
            if (node != null)
            {
                PrintTree(node.leftChild);
                Console.Write(node.value + " ");
                PrintTree(node.rightChild);
            }
        }
    }
}