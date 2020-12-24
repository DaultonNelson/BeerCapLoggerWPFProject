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
        /// Saves a Beer Cap Collection to a special .csv file tied to the User.
        /// </summary>
        /// <param name="capCollection">
        /// The Beer Cap Collection being saved.
        /// </param>
        /// <param name="collectionOwner">
        /// The User that owns the Beer Cap Collection.
        /// </param>
        public static void SaveCapCollectionToFile(this List<BeerCap> capCollection, UserModel collectionOwner)
        {
            List<string> lines = new List<string>();

            foreach (BeerCap cap in capCollection)
            {
                string primaryColorString = cap.PrimaryCapColor.ToSavableColorString();
                string secondaryColorString = cap.SecondaryCapColor.ToSavableColorString();

                lines.Add($"{cap.Id},{cap.CapImagePath},{cap.CapBrandName},{(int)cap.CapQuality},{primaryColorString},{secondaryColorString},{cap.DateAquired.ToShortDateString()},{cap.UnderCapMessage}");
            }

            File.WriteAllLines(collectionOwner.CapCollectonFileName().FullFilePath(), lines);
        }

        /// <summary>
        /// Converts a given color to a Savable string for the application.
        /// </summary>
        /// <param name="colorValue">
        /// The color being converted.
        /// </param>
        /// <returns>
        /// A pipe separated string.
        /// </returns>
        public static string ToSavableColorString (this Color colorValue)
        {
            return $"{colorValue.A}|{colorValue.R}|{colorValue.G}|{colorValue.B}";
        }
    }
}