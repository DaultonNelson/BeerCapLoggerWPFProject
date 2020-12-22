using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BeerCapLog.DataAccess
{
    public class MockBeerCapProcessor
    {
        #region Variables
        /// <summary>
        /// The Qualities available to us.
        /// </summary>
        public Quality[] qualities = new Quality[] { Quality.POOR, Quality.DAMAGED, Quality.SCUFFED, Quality.USED, Quality.MINT };

        /// <summary>
        /// Mock messages for under the cap.
        /// </summary>
        string[] messages = new string[]
        {
            string.Empty,
            "You're Lucky",
            "Made in China",
            "Have you seen my dog on wheels?",
            "Use by 90/29/10..."
        };

        /// <summary>
        /// Mock Brand Names.
        /// </summary>
        string[] brandNames = new string[]
        {
            "Buddy Light",
            "Coronana",
            "Flying Fisheroo",
            "Blue Moon Gibbus",
            "Red's Apple Ail",
            "Moron's Babble",
            "The Bentley",
            "Zebby Bebby",
            "King's Beer",
            "Allura",
            "Softy"
        };

        /// <summary>
        /// An instance of my Random picker class.
        /// </summary>
        RandomPicking picking = new RandomPicking();
        #endregion

        /// <summary>
        /// Generates an amount of mock Beer Caps.
        /// </summary>
        /// <param name="beerCapAmount">
        /// The amount of Beer Caps to be generated.
        /// </param>
        /// <returns>
        /// A collection of mock Beer Caps.
        /// </returns>
        public List<BeerCap> GenerateMockBeerCaps(int beerCapAmount)
        {
            List<BeerCap> output = new List<BeerCap>();

            for (int i = 0; i < beerCapAmount; i++)
            {
                output.Add(
                    new BeerCap(
                        i + 1,
                        CapImage.GetFullPathFromName(
                            picking.GetRandomItem<string>(CapImage.CapImageNames.ToArray())),
                        GenerateMockBrand(i + 1),
                        picking.GetRandomItem<Quality>(qualities),
                        Color.FromArgb(255, (byte)picking.rnd.Next(0, 255), (byte)picking.rnd.Next(0, 255), (byte)picking.rnd.Next(0, 255)),
                        Color.FromArgb(255, (byte)picking.rnd.Next(0, 255), (byte)picking.rnd.Next(0, 255), (byte)picking.rnd.Next(0, 255)),
                        picking.GenerateRandomDate(), //TODO - Change to a randomly picked date.
                        picking.GetRandomItem<string>(messages)
                    )
                );
            }

            return output;
        }

        /// <summary>
        /// Generates a Mock Brand.
        /// </summary>
        /// <param name="index">
        /// The index the Brand should have.
        /// </param>
        /// <returns>
        /// A fake Brand, not create by the user.
        /// </returns>
        public Brand GenerateMockBrand(int index)
        {
            Brand output = new Brand(2000, "NOT FOR USE!");
            
            if (index > brandNames.Length)
            {
                MessageBox.Show("Cannot generate Brand!  Index too large!", "Index Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                return output;
            }

            output.Id = index;
            output.Name = brandNames[index];

            return output;
        }
    }
}