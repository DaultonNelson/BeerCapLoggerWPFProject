using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.DataAccess
{
    public class MockUserProcessor
    {
        #region Variables
        Random rnd = new Random();
        RandomPicking picking = new RandomPicking();

        string[] firstNames = new string[] { "Jim", "John", "Arin", "Sue", "Missy", "Caroline", "Tom", "Frank" };
        string[] lastNames = new string[] { "Sanderson", "Nelson", "Collins", "Apple", "Williams", "Henry", "Bo"};

        public DateTime lowEndDate = new DateTime(1943, 1, 1);

        public int daysFromLowDate;
        #endregion

        /// <summary>
        /// Creates a new Mock User Processor class instance.
        /// </summary>
        public MockUserProcessor()
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
                        picking.GetRandomItem<string>(firstNames),
                        picking.GetRandomItem<string>(lastNames),
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
    }
}