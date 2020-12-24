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
                    DateTime.Parse(props[4])  //Date Joined
                );

                userFromString.GetSavedBeerCapCollection();

                loadedUsers.Add(userFromString);
            }

            return loadedUsers;
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
        public static List<BeerCap> GetSavedBeerCapCollection(this UserModel collectionOwner)
        {
            List<BeerCap> loadedCaps = new List<BeerCap>();

            List<string> lines = collectionOwner.CapCollectonFileName().FullFilePath().LoadFile();

            foreach (string line in lines)
            {
                string[] props = line.Split(',');

                BeerCap capFromString = new BeerCap(
                    int.Parse(props[0]),//ID
                    props[1], //Path
                    props[2], //Brand Name
                    (Quality)int.Parse(props[3]), //Quality
                    props[4].ParseIntoColor(), //Primary Color
                    props[5].ParseIntoColor(), //Secondary Color
                    DateTime.Parse(props[6]), //Date Acquired
                    props[7] //Under Cap Message
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
    }
}