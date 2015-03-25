using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Chapter12
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Define the root of the tree
        /// </summary>
        protected BtNode<T> root;

        /// <summary>
        /// Constructor of the BST
        /// </summary>
        public BinarySearchTree(T value)
        {
            this.root = new BtNode<T>(value);
        }

        //Methods

        /// <summary>
        /// Inserts a new value in the BST
        /// </summary>
        /// <param name="value">Any object that will be inserted</param>
        public void Insert(T value)
        {
            root.Insert(value, null, root);
        }

        /// <summary>Removes an element from the tree if exists
        /// </summary>
        /// <param name="value">the value to be deleted</param>
        public void Remove(T value)
        {
            BtNode<T> nodeToDelete = root.Find(value,root);
            if (nodeToDelete != null)
            {
                root.Remove(nodeToDelete, root);
            }
        }

        /// <summary>Returns whether given value exists in the tree
        /// </summary>
        /// <param name="value">the value to be checked</param>
        /// <returns>true if the value is found in the tree</returns>
        public bool Contains(T value)
        {
            BtNode<T> temp = new BtNode<T>(value);
            bool found = temp.Find(value,root) != null;
            return found;
        }

        public BtNode<T> Root
        {
            get { return root; }
            set { root = value; }
        }

        /// <summary>Traverses and prints the tree</summary>
        public void PrintTree()
        {
            root.PrintTree(root);
            Console.WriteLine();
        }
    }
}
