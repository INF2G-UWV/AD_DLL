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
        /// Represents a binary tree node
        /// </summary>
        /// <typeparam name="T"Specifies the type for the values
        /// in the nodes></typeparam>
        internal class BinaryTreeNode<T> where T : IComparable<T>
        {
            //Value of the node
            internal T value;

            //Parent of the node
            internal BinaryTreeNode<T> parent;

            //Left child of the node
            internal BinaryTreeNode<T> leftChild;

            //right child of the node
            internal BinaryTreeNode<T> rightChild;

            public BinaryTreeNode(T value)
            {
                if (value == null)
                {
                    //Null are not allowed
                    throw new ArgumentNullException("Null values are not allowed!");
                }

                this.value = value;
                this.parent = null;
                this.leftChild = null;
                this.rightChild = null;
            }

            public override string ToString()
            {
                return this.value.ToString();
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;
                return this.CompareTo(other) == 0;
            }

            public int CompareTo(BinaryTreeNode<T> other)
            {
                return this.value.CompareTo(other.value);
            }
        }

        /// <summary>
        /// The root of the tree
        /// </summary>
        private BinaryTreeNode<T> root;

        /// <summary>
        /// Constructs the tree
        /// </summary>
        public BinarySearchTree()
        {
            this.root = null;
        }

        /// <summary>Inserts new value in the binary search tree
        /// </summary>
        /// <param name="value">the value to be inserted</param>
        public void Insert(T value)
        {
            this.root = Insert(value, null, root);
        }
    }
}
