using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.DataAccess
{
    public class MockBeerCapProcessor
    {
        #region Variables
        Quality[] qualities = new Quality[] { Quality.DAMAGED, Quality.POOR, Quality.SCUFFED, Quality.USED, Quality.MINT };

        string[] messages = new string[]
        {
            string.Empty,
            "You're Lucky",
            "Made in China",
            "Have you seen my dog on wheels?",
            "90/29/10..."
        };

        string[] brands = new string[]
        {
            "Bud Light",
            "Corona",
            "Flying Fish",
            "Blue Moon",
            "Red's Apple Ale"
        };

        List<Color> colors = new List<Color>();

        RandomPicking picking = new RandomPicking();
        #endregion

        /// <summary>
        /// Creates a new Mock Beer Cap Processor class instance.
        /// </summary>
        public MockBeerCapProcessor()
        {
            PropertyInfo[] propInfos = typeof(Color).GetProperties();

            foreach (PropertyInfo prop in propInfos)
            {
                colors.Add(Color.FromName(prop.Name));
            }
        }

        /// <summary>
        /// Generates an amount of mock Beer Caps.
        /// </summary>
        /// <param name="beerCapAmount">
        /// The amount of Beer Caps to be generated.
        /// </param>
        /// <returns>
        /// A collection of mock Beer Caps.
        /// </returns>
        public List<BeerCap> GeneratedMockBeerCaps(int beerCapAmount)
        {
            List<BeerCap> output = new List<BeerCap>();

            for (int i = 0; i < beerCapAmount; i++)
            {
                output.Add(
                    new BeerCap(
                        i + 1,
                        CapImage.GetFullPathFromName(
                            picking.GetRandomItem<string>(CapImage.CapImageNames.ToArray())),
                        new Brand
                        (
                            i + 1,
                            picking.GetRandomItem<string>(brands)
                        ),
                        picking.GetRandomItem<Quality>(qualities),
                        picking.GetRandomItem<Color>(colors.ToArray()),
                        picking.GetRandomItem<Color>(colors.ToArray()),
                        picking.GetRandomItem<string>(messages)
                    )
                );
            }

            return output;
        }
    }
}