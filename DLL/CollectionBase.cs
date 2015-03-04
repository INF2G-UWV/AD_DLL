namespace DLL
{
    public class CollectionBase<T>
    {
        private readonly CollectionBase<T> collection = new CollectionBase<T>();

        public void Add(T item)
        {
            collection.Add(item);
        }

        public void Remove(T item)
        {
            collection.Remove(item);
        }

        private void Clear()
        {
            collection.Clear();
        }

        public int Count()
        {
            return collection.Count();
        }
    }
}