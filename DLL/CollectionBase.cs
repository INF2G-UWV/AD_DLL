namespace DLL
{
    /// <summary>
    ///     Collection base.
    ///     Base class for collection implementations.
    ///     Author: Martijn Buurman & Xing Woo - INF2G
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionBase<T>
    {
        private readonly CollectionBase<T> collection = new CollectionBase<T>();

        /// <summary>
        ///     Add item
        /// </summary>
        /// <param name="item">item</param>
        public void Add(T item)
        {
            collection.Add(item);
        }

        /// <summary>
        ///     Remove item
        /// </summary>
        /// <param name="item">item</param>
        public void Remove(T item)
        {
            collection.Remove(item);
        }

        /// <summary>
        ///     Clear collection
        /// </summary>
        private void Clear()
        {
            collection.Clear();
        }

        /// <summary>
        ///     Get number of items
        /// </summary>
        /// <returns>int</returns>
        public int Count()
        {
            return collection.Count();
        }
    }
}