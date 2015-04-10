using System;

namespace DLL
{
    /// <summary>
    ///     Binary Search Tree
    ///     Author: Xing Woo - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        ///     Define the root of the tree
        /// </summary>
        protected BtNode<T> root;

        /// <summary>
        ///     Constructor of the BST
        /// </summary>
        public BinarySearchTree(T value)
        {
            root = new BtNode<T>(value);
        }

        /// <summary>
        ///     Get/Set value
        /// </summary>
        public BtNode<T> Root
        {
            get { return root; }
            set { root = value; }
        }

        //Methods

        /// <summary>
        ///     Inserts a new value in the BST
        /// </summary>
        /// <param name="value">Any object that will be inserted</param>
        public void Insert(T value)
        {
            root.Insert(value, null, root);
        }

        /// <summary>
        ///     Removes an element from the tree if exists
        /// </summary>
        /// <param name="value">the value to be deleted</param>
        public void Remove(T value)
        {
            var nodeToDelete = root.Find(value, root);
            if (nodeToDelete != null)
            {
                root.Remove(nodeToDelete, root);
            }
        }

        /// <summary>
        ///     Returns whether given value exists in the tree
        /// </summary>
        /// <param name="value">the value to be checked</param>
        /// <returns>true if the value is found in the tree</returns>
        public bool Contains(T value)
        {
            var temp = new BtNode<T>(value);
            var found = temp.Find(value, root) != null;
            return found;
        }

        /// <summary>Traverses and prints the tree</summary>
        public void PrintTree()
        {
            root.PrintTree(root);
            Console.WriteLine();
        }
    }
}