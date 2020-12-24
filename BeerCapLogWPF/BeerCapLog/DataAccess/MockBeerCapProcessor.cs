using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

//TODO - Maybe delete this whole class
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
        /// Brand Names.
        /// </summary>
        public string[] brandNames = new string[]
        {
            "American Barley", "Amstell Light", "Angry Orchard",
            "Banquet", "Blue Moon", "Bud Light", "Bud Light Lime", "Budweiser Classic", "Budweiser Modern",
            "Coors Light", "Corona Extra", "Corona Light", "Corona Premier", "C Spiral",
            "Evil Genius", "Evolution Craft Brewing", "Flying Fish", "Goose Island", "Harp Lager",
            "Heineken", "Michelob Lite", "Mike's", "Moosehead Brewery", "New Belgium Brewing",
            "Red Apple Ale", "Red Apple Ale Blue", "Red Apple Ale Special", "River Fish",
            "Rolling Rock", "Samuel Adams", "Smirnoff", "Sun", "Twisted Tea", "Victory Brewing", "Yards Brewing"
        };

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
                        picking.GetRandomItem<string>(brandNames),
                        picking.GetRandomItem<Quality>(qualities),
                        Color.FromArgb(255, (byte)picking.rnd.Next(0, 255), (byte)picking.rnd.Next(0, 255), (byte)picking.rnd.Next(0, 255)),
                        Color.FromArgb(255, (byte)picking.rnd.Next(0, 255), (byte)picking.rnd.Next(0, 255), (byte)picking.rnd.Next(0, 255)),
                        picking.GenerateRandomDate(),
                        picking.GetRandomItem<string>(messages)
                    )
                );
            }

            return output;
        }
    }
}