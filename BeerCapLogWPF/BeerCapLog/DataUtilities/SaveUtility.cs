using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.DataUtilities
{
    public static class SaveUtility
    {
        /// <summary>
        /// Saves a List of User Models to a .csv file.
        /// </summary>
        /// <param name="userModels">
        /// The UserModels we're saving.
        /// </param>
        public static void SaveToUsersFile(this List<UserModel> userModels)
        {
            List<string> lines = new List<string>();

            foreach (UserModel user in userModels)
            {
                lines.Add($"{user.Id},{user.FirstName},{user.LastName},{user.DateOfBirth.ToShortDateString()},{user.DateJoined.ToShortDateString()}");
            }

            File.WriteAllLines(UtilityFilePaths.UserModelsFile.FullFilePath(), lines);
        }

        /// <summary>
        /// Saves a Beer Cap Collection to a .csv file.
        /// </summary>
        /// <param name="capCollection">
        /// The Beer Cap Collection being saved.
        /// </param>
        public static void SaveCapCollectionToFile(this CapCollection<BeerCap> capCollection)
        {
            //TODO - Save Beer Cap Collection at index.
        }
    }
}