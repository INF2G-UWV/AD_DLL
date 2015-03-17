using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    /// <summary>
    ///     PriorityQueue Class
    ///     Chapter 5
    /// </summary>

    public struct pqItem
    {
        public string name;
        public int priority;
    }

    public class PriorityQueue<T> : Queue<T>
    {
        

    }
}
