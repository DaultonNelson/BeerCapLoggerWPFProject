using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    int.Parse(props[0]), //id
                    props[1], //First Name
                    props[2], //Last Name
                    DateTime.Parse(props[3]), //Date of Birth
                    DateTime.Parse(props[4])  //Date Joined
                );

                loadedUsers.Add(userFromString);
            }

            return loadedUsers;
        }

        /// <summary>
        /// Makes Cap Collections from a collection of lines.
        /// </summary>
        /// <param name="lines">
        /// The lines this function tries to convert from.
        /// </param>
        /// <returns>
        /// A list of Beer Cap Collections.
        /// </returns>
        public static List<CapCollection<BeerCap>> CovertLinesIntoCapCollections(this List<string> lines)
        {
            List<CapCollection<BeerCap>> loadedCollections = new List<CapCollection<BeerCap>>();

            return loadedCollections;
        }
    }
}