using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.DataUtilities
{
    public static class UtilityFilePaths
    {
        #region Variables
        /// <summary>
        /// The path that leads to the Utilities folder directory.
        /// </summary>
        public static string FolderPath
        {
            get
            {
                return @"D:\Side Projects\BottleCapCollection\BeerCapLoggerWPFProject\UtilityFiles\";
            }
        }

        /// <summary>
        /// The name of the UserModels list file.
        /// </summary>
        public static string UserModelsFile { get { return "UserModels.csv"; } }
        /// <summary>
        /// The string to get attached to a Cap Collection Save File.
        /// </summary>
        public static string CapCollectionFileSuffix { get { return "CapCollection.csv"; } }
        #endregion

        /// <summary>
        /// Returns the full file path towards a file.
        /// </summary>
        /// <param name="file">
        /// The name of the file.
        /// </param>
        /// <returns>
        /// The full file path.
        /// </returns>
        public static string FullFilePath(this string file)
        {
            return $"{FolderPath}{file}";
        }

        /// <summary>
        /// Generates a file name based on given User information for saving their cap collection.
        /// </summary>
        /// <param name="user">
        /// The user this function pulls information from.
        /// </param>
        /// <returns>
        /// A unique cap collection file name for the user.
        /// </returns>
        public static string CapCollectonFileName (this UserModel user)
        {
            return $"{user.Id}{user.FirstName}{user.LastName}{CapCollectionFileSuffix}";
        }
    }
}