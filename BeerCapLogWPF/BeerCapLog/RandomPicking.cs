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
        /// <summary>
        /// An instance of the System Random class.
        /// </summary>
        public Random rnd = new Random();

        /// <summary>
        /// The lowest, earliest date possible.
        /// </summary>
        public DateTime lowEndDate = new DateTime(1943, 1, 1);

        /// <summary>
        /// A private variable to hold how many days it's been between the low end date and now.
        /// </summary>
        public int daysFromLowDate;
        #endregion

        /// <summary>
        /// Creates a new instance of the Random Picking class. 
        /// </summary>
        public RandomPicking()
        {
            daysFromLowDate = (DateTime.Today - lowEndDate).Days;
        }

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
        
        /// <summary>
        /// Generates a random date between Jan 1 1943, and today.
        /// </summary>
        /// <returns>
        /// A random date.
        /// </returns>
        public DateTime GenerateRandomDate()
        {
            DateTime output = new DateTime();

            output = lowEndDate.AddDays(rnd.Next(daysFromLowDate));

            return output;
        }
    }
}
