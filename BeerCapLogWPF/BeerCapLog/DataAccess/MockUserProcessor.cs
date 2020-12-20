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
        /// <summary>
        /// An instance of the Random class.
        /// </summary>
        Random rnd = new Random();
        /// <summary>
        /// An instance of my Random picking class.
        /// </summary>
        RandomPicking picking = new RandomPicking();

        /// <summary>
        /// Mock First Names.
        /// </summary>
        string[] firstNames = new string[] { "Jim", "John", "Arin", "Sue", "Missy", "Caroline", "Tom", "Frank" };
        /// <summary>
        /// Mock Last Names.
        /// </summary>
        string[] lastNames = new string[] { "Sanderson", "Nelson", "Collins", "Apple", "Williams", "Henry", "Bo"};

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