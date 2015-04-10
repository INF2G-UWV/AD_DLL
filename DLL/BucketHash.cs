using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DLL
{
    /// <summary>
    ///     BucketHash hashing class.
    ///     Uses multiple ArrayLists for storage
    ///     Author: Marcel Schoeber - INF2G
    /// </summary>
    public class BucketHash
    {
        //fields
        private const int SIZE = 10007;
        private readonly ArrayList[] data;

        /// <summary>
        ///     Constructor of class BucketHash.
        /// </summary>
        public BucketHash()
        {
            data = new ArrayList[SIZE];
            for (var i = 0; i <= SIZE - 1; i++)
            {
                data[i] = new ArrayList(4);
            }
        }

        /// <summary>
        ///     Convert string to hash value.
        /// </summary>
        /// <param name="s">String - input</param>
        /// <returns>Int - hash value</returns>
        private int Hash(string s)
        {
            var tot = 0;

            //Convert input string to chararray
            var charray = s.ToCharArray();

            //Convert to hash
            for (var i = 0; i <= s.Length - 1; i++)
            {
                var val = tot + charray[i];
                val *= 37;
                tot += val;
            }

            tot = tot%data.GetUpperBound(0);

            if (tot < 0)
            {
                tot += data.GetUpperBound(0);
            }

            return tot;
        }

        /// <summary>
        ///     Insert string into ArrayList.
        /// </summary>
        /// <param name="item">String - item</param>
        public void Insert(string item)
        {
            var hashValue = Hash(item);
            if (!data[hashValue].Contains(item))
            {
                data[hashValue].Add(item);
            }
        }

        /// <summary>
        ///     Returns hash value of given string
        /// </summary>
        /// <param name="item">String - item</param>
        /// <returns>Int hash</returns>
        public int GetHashValue(string item)
        {
            return Hash(item);
        }

        /// <summary>
        ///     Checks if string exists in collection
        /// </summary>
        /// <param name="item">String - item</param>
        /// <returns>bool - exists</returns>
        public bool Exists(string item)
        {
            var hashValue = Hash(item);
            return data[hashValue].Contains(item);
        }

        /// <summary>
        ///     Get a dictionary list of items in buckethash.
        /// </summary>
        /// <returns>int, string - hashvalue, item</returns>
        public Dictionary<int, string> GetList()
        {
            //Fetch items
            return
                (from itemlist in data
                    where itemlist.Count > 0
                    from o in itemlist.Cast<object>().Where(item => item != null)
                    select o).ToDictionary(o => GetHashValue(o.ToString()), o => o.ToString());
        }

        /// <summary>
        ///     Remove string from ArrayList.
        /// </summary>
        /// <param name="item">String - item</param>
        public void Remove(string item)
        {
            var hashValue = Hash(item);
            if (data[hashValue].Contains(item))
            {
                data[hashValue].Remove(item);
            }
        }
    }
}