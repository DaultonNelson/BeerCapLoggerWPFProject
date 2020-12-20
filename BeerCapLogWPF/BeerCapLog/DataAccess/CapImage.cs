using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeerCapLog.DataAccess
{
    public static class CapImage
    {
        /// <summary>
        /// The path that goes to the CapImages folder.
        /// </summary>
        public static string FolderPath {
            get
            {
                return @"D:\Side Projects\BottleCapCollection\BeerCapLoggerWPFProject\BeerCapImages\";
            }
        }

        #region Cap Image File Names
        public static string AmericanBarley { get { return "AmericanBarley"; } }
        public static string AmstelLight { get { return "AmstelLight"; } }
        public static string AngryOrchard { get { return "AngryOrchard"; } }
        public static string Banquet { get { return "Banquet"; } }
        public static string BlueMoon { get { return "BlueMoon"; } }
        public static string BudLight { get { return "BudLight"; } }
        public static string BudLightLime { get { return "BudLightLime"; } }
        public static string BudweiserClassic { get { return "BudweiserClassic"; } }
        public static string BudweiserModern { get { return "BudweiserModern"; } }
        public static string CoorsLight { get { return "CoorsLight"; } }
        public static string CoronaExtra { get { return "CoronaExtra"; } }
        public static string CoronaLight { get { return "CoronaLight"; } }
        public static string CoronaPremier { get { return "CoronaPremier"; } }
        public static string CSpiral { get { return "CSpiral"; } }
        public static string EvilGenius { get { return "EvilGenius"; } }
        public static string EvolutionCraftBrewing { get { return "EvolutionCraftBrewing"; } }
        public static string FlyingFish { get { return "FlyingFish"; } }
        public static string GooseIsland { get { return "GooseIsland"; } }
        public static string HarpLager { get { return "HarpLager"; } }
        public static string Heineken { get { return "Heineken"; } }
        public static string MichelobLite { get { return "MichelobLite"; } }
        public static string MichelobUltra { get { return "MichelobUltra"; } }
        public static string Mikes { get { return "Mikes"; } }
        public static string MooseheadBrewery { get { return "MooseheadBrewery"; } }
        public static string NewBelgiumBrewing { get { return "NewBelgiumBrewing"; } }
        public static string RedAppleAle { get { return "RedAppleAle"; } }
        public static string RedAppleAleBlue { get { return "RedAppleAleBlue"; } }
        public static string RedAppleAleSpecial { get { return "RedAppleAleSpecial"; } }
        public static string RiverFish { get { return "RiverFish"; } }
        public static string RollingRock { get { return "RollingRock"; } }
        public static string SamuelAdams { get { return "SamuelAdams"; } }
        public static string Smirnoff { get { return "Smirnoff"; } }
        public static string Sun { get { return "Sun"; } }
        public static string TwistedTea { get { return "TwistedTea"; } }
        public static string VictoryBrewing { get { return "VictoryBrewing"; } }
        public static string YardsBrewing { get { return "YardsBrewing"; } }
        #endregion
        
        /// <summary>
        /// A collection of all the Cap Image names.
        /// </summary>
        public static string[] CapImageNames = new string[] {
            AmericanBarley, AmstelLight, AngryOrchard, Banquet, BlueMoon,
            BudLight, BudLightLime, BudweiserClassic, BudweiserModern, CoorsLight,
            CoronaExtra, CoronaLight, CoronaPremier, CSpiral, EvilGenius, EvolutionCraftBrewing,
            FlyingFish, GooseIsland, HarpLager, Heineken, MichelobLite, MichelobUltra, Mikes,
            MooseheadBrewery, NewBelgiumBrewing, RedAppleAle, RedAppleAleBlue, RedAppleAleSpecial,
            RiverFish, RollingRock, SamuelAdams, Smirnoff, Sun, TwistedTea, VictoryBrewing, YardsBrewing
        };

        /// <summary>
        /// Returns the full path to an Image file via given name.
        /// </summary>
        /// <param name="capImageName">
        /// The name of the Cap Image wanted.
        /// </param>
        /// <returns>
        /// The full path directed towards the image file.
        /// </returns>
        public static string GetFullPathFromName(string capImageName)
        {
            if (!CapImageNames.Contains(capImageName))
            {
                MessageBox.Show("Invalid name given to CapImage function!", "Invalid Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }

            return $"{FolderPath}{capImageName}.png";
        }
    }
}