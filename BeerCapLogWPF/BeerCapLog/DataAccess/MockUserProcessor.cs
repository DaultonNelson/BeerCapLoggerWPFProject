using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO - Maybe delete this whole class
namespace BeerCapLog.DataAccess
{
    public class MockUserProcessor
    {
        #region Variables
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
        #endregion

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

            MockBeerCapProcessor mbcp = new MockBeerCapProcessor();

            for (int i = 0; i < amountOfUsers; i++)
            {
                output.Add
                (
                    new UserModel
                    (
                        i + 1,
                        picking.GetRandomItem<string>(firstNames),
                        picking.GetRandomItem<string>(lastNames),
                        picking.GenerateRandomDate()
                    )
                );
            }

            return output;
        }
    }
}