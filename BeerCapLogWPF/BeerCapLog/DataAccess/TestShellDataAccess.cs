using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Quality { POOR, DAMAGED, SCUFFED, USED, MINT }

namespace BeerCapLog.DataAccess
{
    public class TestShellDataAccess
    {
        #region Variables
        Random rnd = new Random();

        DateTime lowEndDate = new DateTime(1943, 1, 1);

        string[] firstNames = new string[] { "Jim", "John", "Arin", "Sue", "Missy", "Caroline", "Tom", "Frank" };
        string[] lastNames = new string[] { "Sanderson", "Nelson", "Collins", "Apple", "Williams", "Henry", "Bo"};
        int daysFromLowDate;
        #endregion

        /// <summary>
        /// Creates a new Test Shell Data Access class instance
        /// </summary>
        public TestShellDataAccess()
        {
            daysFromLowDate = (DateTime.Today - lowEndDate).Days;
        }

        /// <summary>
        /// Generates a List of Mock Users for us to Test.
        /// </summary>
        /// <param name="amountOfUsers">
        /// The amount of Mock Users to generate.
        /// </param>
        /// <returns>
        /// Mock Users
        /// </returns>
        public List<UserModel> GenerateMockUsers (int amountOfUsers)
        {
            List<UserModel> output = new List<UserModel>();

            for (int i = 0; i < amountOfUsers; i++)
            {
                output.Add
                (
                    new UserModel
                    (
                        i + 1,
                        GetRandomItem<string>(firstNames),
                        GetRandomItem<string>(lastNames),
                        GenerateRandomDate()
                    )
                );
            }

            return output;
        }

        /// <summary>
        /// Generates a random date between Jan 1 1943, and today.
        /// </summary>
        /// <returns></returns>
        private DateTime GenerateRandomDate()
        {
            DateTime output = new DateTime();

            output = lowEndDate.AddDays(rnd.Next(daysFromLowDate));

            return output;
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
        public T GetRandomItem<T> (T[] data)
        {
            return data[rnd.Next(0, data.Length)];
        }
    }
}