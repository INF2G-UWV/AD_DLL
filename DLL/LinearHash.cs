using System.Collections.Generic;
using System.Linq;

namespace DLL
{
    /// <summary>
    ///     LinearHash
    ///     Uses linear probing
    ///     Author: Marcel Schoeber - INF2G
    /// </summary>
    public class LinearHash
    {
        //fields
        private const int SIZE = 10007;
        private readonly string[] data;

        /// <summary>
        ///     Constructor of class LinearHash.
        /// </summary>
        public LinearHash()
        {
            data = new string[SIZE];
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
        ///     Insert string into Array.
        /// </summary>
        /// <param name="item">String - item</param>
        public void Insert(string item)
        {
            var hashValue = Hash(item);
            if (data[hashValue] == null)
            {
                data[hashValue] = item;
            }
            else
            {
                //Use Linear Probing
                var col = 1;
                var emptyFound = false;
                while (!emptyFound)
                {
                    var newHash = hashValue + col;
                    if (data[newHash] == null)
                    {
                        data[(newHash)] = item;
                        emptyFound = true;
                    }
                    col++;
                }
            }
        }

        /// <summary>
        ///     Returns hash value of giving string
        /// </summary>
        /// <param name="item">String - item</param>
        /// <returns>Int hash</returns>
        public int GetHashValue(string item)
        {
            return Hash(item);
        }

        /// <summary>
        ///     Checks if string exists in array.
        /// </summary>
        /// <param name="item">String - item</param>
        /// <returns>bool - exists</returns>
        public bool Exists(string item)
        {
            var hashValue = Hash(item);
            if (data[hashValue] != null)
            {
                return data[hashValue].Contains(item);
            }
            return false;
        }

        /// <summary>
        ///     Get a dictionary list of items in linearhash.
        /// </summary>
        /// <returns>string,int - item, hashvalue</returns>
        public Dictionary<string, int> GetList()
        {
            return data.Where(t => t != null).ToDictionary(t => t, GetHashValue);
        }

        /// <summary>
        ///     Remove string from Array.
        /// </summary>
        /// <param name="item">String - item</param>
        public void Remove(string item)
        {
            var hashValue = Hash(item);
            if (data[hashValue] != null)
            {
                if (data[hashValue].Contains(item))
                {
                    data[hashValue] = null;
                }
                else
                {
                    //Use Linear Probing
                    var col = 1;
                    var itemFound = false;
                    while (!itemFound)
                    {
                        var newHash = hashValue + col;
                        if (data[newHash] != null)
                        {
                            if (data[newHash].Contains(item))
                            {
                                data[newHash] = null;
                                itemFound = true;
                            }
                        }
                        col++;
                    }
                }
            }
        }
    }
}