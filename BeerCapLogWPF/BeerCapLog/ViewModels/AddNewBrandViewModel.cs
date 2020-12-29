using BeerCapLog.DataUtilities;
using BeerCapLog.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

using MessageBox = System.Windows.MessageBox;
using Screen = Caliburn.Micro.Screen;

namespace BeerCapLog.ViewModels
{
    public class AddNewBrandViewModel : Screen
    {
        #region Variables
        /// <summary>
        /// Manages the Windows for Caliburn Micro.
        /// </summary>
        private IWindowManager manager = new WindowManager();
        #endregion

        #region Created Brand Name
        private string _createdBrandName;

        public string CreatedBrandName
        {
            get { return _createdBrandName; }
            set { _createdBrandName = value; }
        }
        #endregion
        #region Selected Primary Color
        private Color _selectedPrimaryColor;

        public Color SelectedPrimaryColor
        {
            get { return _selectedPrimaryColor; }
            set { _selectedPrimaryColor = value; }
        }
        #endregion
        #region Selected Secondary Color
        private Color _selectedSecondaryColor;

        public Color SelectedSecondaryColor
        {
            get { return _selectedSecondaryColor; }
            set { _selectedSecondaryColor = value; }
        } 
        #endregion

        /// <summary>
        /// Browses for a Brand Image when called.
        /// </summary>
        public void BrowseForBrandImage()
        {
            //TODO - Implement Browse For Brand Image function.

            //TODO - Might move this chunk of code to somewhere else.
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "PNG Files (*.png)|*.png";
                ofd.RestoreDirectory = true;
                ofd.Title = "Open Image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = ofd.SafeFileName.FullCapImagePath();

                    if (File.Exists(imagePath))
                    {
                        if (MessageBox.Show("A file similar to this already exists.  Overwrite it?", "Already Existing File", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

                    var fileStream = File.Create(imagePath);
                    var openedStream = ofd.OpenFile();
                    openedStream.Seek(0, SeekOrigin.Begin);
                    openedStream.CopyTo(fileStream);
                    fileStream.Close();
                }
            }
        }

        /// <summary>
        /// Tries and creates a Brand through the Form data.
        /// </summary>
        public void TryCreateBrand()
        {
            //TODO - Flesh out TryCreateBrand
            if (ValidateFormDate())
            {
                MessageBox.Show($"{CreatedBrandName} {SelectedPrimaryColor.ToString()} {SelectedSecondaryColor.ToString()}");
                //TODO - Create Brand from Form Data
                BrandModel newBrand = new BrandModel(
                    5500, //ID
                    "Brand Name", //Brand Name
                    "Sally", //FileName
                    Color.FromArgb(0, 0, 0, 0), //Primary Color
                    Color.FromArgb(0, 0, 0, 0)); //Secondary Color

                //TODO - Save all Brands
            }
        }

        /// <summary>
        /// Checks if the given Form data is valid.
        /// </summary>
        /// <returns>
        /// True if information is valid, or false if not.
        /// </returns>
        private bool ValidateFormDate()
        {
            bool output = true;

            if (CreatedBrandName == null || CreatedBrandName == string.Empty)
            {
                MessageBox.Show("Brand must have a name!", "Null Reference Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            //TODO - Validate Brand Image

            if (SelectedPrimaryColor.A < 255 || SelectedPrimaryColor.A < 255)
            {
                MessageBox.Show("The Brand's colors must be fully opaque (No Transparency)!", "Invalid Information", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            return output;
        }
    }
}
