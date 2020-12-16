using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog
{
    public class RandomPicking
    {
        #region Variables
        public Random rnd = new Random();
        #endregion
        
        /// <summary>
        /// Grabs a random item from a specified array.
        /// </summary>
        /// <typeparam name="T">
        /// The Type we're looking for.
        /// </typeparam>
        /// <param name="data">
        /// The array we're picking from.
        /// </param>
        /// <returns>
        /// A random item from the specified array.
        /// </returns>
        public T GetRandomItem<T>(T[] data)
        {
            return data[rnd.Next(0, data.Length)];
        }
    }
}
