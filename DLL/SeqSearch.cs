namespace DLL
{
    /// <summary>
    ///     Sequential searching algorithm.
    ///     Checks every item sequentially in a generic array until a match is found.
    /// </summary>
    internal class SeqSearch
    {
        /// <summary>
        ///     Searching method.
        ///     Returns true if a match is found.
        /// </summary>
        /// <typeparam name="T">Generic method</typeparam>
        /// <param name="arr">Generic array - input</param>
        /// <param name="sValue">Generic value - find this value within the array</param>
        /// <returns></returns>
        private bool Search<T>(T[] arr, T sValue)
        {
            for (var index = 0; index < arr.Length - 1; index++)
            {
                if (arr[index].Equals(sValue))
                {
                    return true;
                }
            }
            return false;
        }
    }
}