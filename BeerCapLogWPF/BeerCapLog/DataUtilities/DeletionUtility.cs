using BeerCapLog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeerCapLog.DataUtilities
{
    public static class DeletionUtility
    {
        /// <summary>
        /// Deletes a file at a given file path.
        /// </summary>
        /// <param name="filePath">
        /// The path to the file.
        /// </param>
        public static void DeleteFile(this string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            File.Delete(filePath);
        }

        /// <summary>
        /// Deletes a given User and their files.
        /// </summary>
        /// <param name="user">
        /// The User to remove.
        /// </param>
        /// <returns>
        /// True if deletion was successful, false if not.
        /// </returns>
        public static bool DeleteUserProfile(this UserModel user)
        {
            bool output = false;
            
            List<UserModel> savedUsers = UtilityFilePaths.UserModelsFile.FullUtilitiesPath().LoadFile().ConvertLinesIntoUsers();

            if (!savedUsers.Contains(user))
            {
                MessageBox.Show("User does not exist!", "Null Reference Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return output;
            }
            else
            {
                savedUsers.Remove(user);
            }

            savedUsers.SaveToUsersFile();
            
            user.CapCollectonFileName().FullUtilitiesPath().DeleteFile();

            output = true;
            return output;
        }
    }
}