using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class CollectionBase<T>
    {
        private CollectionBase<T> collection = new CollectionBase<T>();

        public void Add(T item)
        {
            collection.Add(item);
        }

        public void Remove(T item)
        {
            collection.Remove(item);
        }

        private new void Clear()
        {
            collection.Clear();
        }

        public new int Count()
        {
            return collection.Count();
        }
    }
}
