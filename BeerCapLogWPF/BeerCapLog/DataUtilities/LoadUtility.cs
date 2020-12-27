using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BeerCapLog.DataUtilities
{
    public static class LoadUtility
    {
        /// <summary>
        /// Loads lines from a file.
        /// </summary>
        /// <param name="file">
        /// The path towards the file to load.
        /// </param>
        /// <returns>
        /// A List of strings/lines.
        /// </returns>
        public static List<string> LoadFile(this string file)
        {
            List<string> output = new List<string>();

            if (!File.Exists(file))
            {
                return new List<string>();
            }

            output = File.ReadAllLines(file).ToList();

            return output;
        }

        /// <summary>
        /// Makes Users from a collection of lines.
        /// </summary>
        /// <param name="lines">
        /// The lines this function tries to convert from.
        /// </param>
        /// <returns>
        /// A list of Users.
        /// </returns>
        public static List<UserModel> ConvertLinesIntoUsers(this List<string> lines)
        {
            List<UserModel> loadedUsers = new List<UserModel>();

            foreach (string line in lines)
            {
                string[] props = line.Split(',');

                UserModel userFromString = new UserModel(
                    int.Parse(props[0]), //ID
                    props[1], //First Name
                    props[2], //Last Name
                    DateTime.Parse(props[3]), //Date of Birth
                    DateTime.Parse(props[4]), //Time Last Logged in
                    DateTime.Parse(props[5])  //Date Joined
                );

                userFromString.GetSavedBeerCapCollection();

                loadedUsers.Add(userFromString);
            }

            return loadedUsers;
        }

        /// <summary>
        /// Makes Brands from a collection of lines.
        /// </summary>
        /// <param name="lines">
        /// The lines being converted.
        /// </param>
        /// <returns>
        /// A list of Brands.
        /// </returns>
        public static List<BrandModel> ConvertLinesIntoBrands(this List<string> lines)
        {
            List<BrandModel> loadedBrands = new List<BrandModel>();

            foreach (string line in lines)
            {
                string[] props = line.Split(',');

                BrandModel brand = new BrandModel(
                    int.Parse(props[0]), //ID
                    props[1], //Name
                    props[2], //Path
                    props[3].ParseIntoColor(), //Primary
                    props[4].ParseIntoColor() //Secondary
                );

                loadedBrands.Add(brand);
            }

            return loadedBrands;
        }

        /// <summary>
        /// Gets a saved Beer Cap Collection based on the User.
        /// </summary>
        /// <param name="collectionOwner">
        /// The owner of the Beer Cap collection.
        /// </param>
        /// <returns>
        /// The User's Beer Cap collection.
        /// </returns>
        public static List<BeerCapModel> GetSavedBeerCapCollection(this UserModel collectionOwner)
        {
            List<BeerCapModel> loadedCaps = new List<BeerCapModel>();

            List<string> lines = collectionOwner.CapCollectonFileName().FullFilePath().LoadFile();

            foreach (string line in lines)
            {
                string[] props = line.Split(',');

                BeerCapModel capFromString = new BeerCapModel(
                    int.Parse(props[0]),//ID
                    int.Parse(props[1]).GetBrandFromIndex(), //Brand
                    (Quality)int.Parse(props[2]), //Quality
                    DateTime.Parse(props[3]), //Date Acquired
                    props[4] //Under Cap Message
                );

                loadedCaps.Add(capFromString);
            }

            return loadedCaps;
        }

        /// <summary>
        /// Tries and Parses a given string into a color.
        /// </summary>
        /// <param name="savedData">
        /// The string that's being parsed.
        /// </param>
        /// <returns>
        /// A new Color.
        /// </returns>
        public static Color ParseIntoColor(this string savedData)
        {
            Color output = new Color();

            string[] colorProp = savedData.Split('|');

            byte propA = byte.Parse(colorProp[0]);
            byte propR = byte.Parse(colorProp[1]);
            byte propG = byte.Parse(colorProp[2]);
            byte propB = byte.Parse(colorProp[3]);

            output = Color.FromArgb(propA, propR, propG, propB);

            return output;
        }

        /// <summary>
        /// Tries and Parses a given int into a Brand.
        /// </summary>
        /// <param name="index">
        /// The index of the Brand being parsed.
        /// </param>
        /// <returns>
        /// A full Brand.
        /// </returns>
        public static BrandModel GetBrandFromIndex(this int index)
        {
            return UtilityFilePaths.BrandModelsFile.FullFilePath().LoadFile().ConvertLinesIntoBrands().Where(x => x.Id == index).First();
        }
    }
}