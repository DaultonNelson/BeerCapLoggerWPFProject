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
        public static string CapImageFolderPath {
            get
            {
                return @"D:\Side Projects\BottleCapCollection\BeerCapLoggerWPFProject\BeerCapImages\SavedBrandCaps\";
            }
        }

        /// <summary>
        /// Returngs a full path towards a file in the CapImages area.
        /// </summary>
        /// <param name="capImageFileName">
        /// The Cap Image file name.
        /// </param>
        /// <returns>
        /// The full Cap Image file path.
        /// </returns>
        public static string FullCapImagePath(this string capImageFileName)
        {
            if (!capImageFileName.Contains(".png"))
            {
                MessageBox.Show("File Name must have .png in it!", "Invalid Backend Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }

            return $"{CapImageFolderPath}{capImageFileName}";
        }
    }
}