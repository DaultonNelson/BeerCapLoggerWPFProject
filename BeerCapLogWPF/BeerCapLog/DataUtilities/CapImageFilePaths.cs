using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeerCapLog.DataUtilities
{
    public static class CapImageFilePaths
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