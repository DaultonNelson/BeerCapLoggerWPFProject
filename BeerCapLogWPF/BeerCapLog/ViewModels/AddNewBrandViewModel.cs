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

        #region Existing Brand Images
        private BindableCollection<string> _existingBrandImages;

        public BindableCollection<string> ExistingBrandImages
        {
            get { return _existingBrandImages; }
            set {
                _existingBrandImages = value;
                NotifyOfPropertyChange(() => ExistingBrandImages);
            }
        } 
        #endregion

        #region Created Brand Name
        private string _createdBrandName;

        public string CreatedBrandName
        {
            get { return _createdBrandName; }
            set { _createdBrandName = value; }
        }
        #endregion
        #region Selected Brand Image
        private string _selectedBrandImage;

        public string SelectedBrandImage
        {
            get { return _selectedBrandImage; }
            set {
                _selectedBrandImage = value;
                NotifyOfPropertyChange(() => SelectedBrandImage);
            }
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
        /// Manages the Windows for Caliburn Micro.
        /// </summary>
        private IWindowManager manager = new WindowManager();
        /// <summary>
        /// The Add New Cap View Model that this window was opened from.
        /// </summary>
        private AddNewCapViewModel addCapView;
        #endregion

        /// <summary>
        /// Creates a new instance of the Add New Brand View.
        /// </summary>
        /// <param name="newCapModel">
        /// The Add Cap view the user is in.
        /// </param>
        public AddNewBrandViewModel(AddNewCapViewModel newCapModel)
        {
            addCapView = newCapModel;

            List<string> savedBrandImages = Directory.GetFiles(CapImageFilePaths.CapImageFolderPath).ToList();

            ExistingBrandImages = new BindableCollection<string>(savedBrandImages);
            if (ExistingBrandImages.Count != 0)
            {
                SelectedBrandImage = ExistingBrandImages.First(); 
            }
        }

        /// <summary>
        /// Browses for a Brand Image when called.
        /// </summary>
        public void BrowseForBrandImage()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "PNG Files (*.png)|*.png";
                //ofd.RestoreDirectory = true;
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
                    
                    List<string> populatedExistingImages = ExistingBrandImages.ToList();
                    populatedExistingImages.Add(ofd.SafeFileName.FullCapImagePath());
                    populatedExistingImages.Sort();

                    ExistingBrandImages = new BindableCollection<string>(populatedExistingImages);
                    SelectedBrandImage = ExistingBrandImages.First();

                    MessageBox.Show("File Uploaded, check Existing Image Dropdown.", "Upload Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        /// Tries and creates a Brand through the Form data.
        /// </summary>
        public void TryCreateBrand()
        {
            if (ValidateFormDate())
            {
                //MessageBox.Show($"{CreatedBrandName} {SelectedPrimaryColor.ToString()} {SelectedSecondaryColor.ToString()}");

                List<BrandModel> savedBrands = UtilityFilePaths.BrandModelsFile.FullUtilitiesPath().LoadFile().ConvertLinesIntoBrands();
                
                BrandModel newBrand = new BrandModel(
                    savedBrands.Count + 1, //ID
                    CreatedBrandName, //Brand Name
                    SelectedBrandImage.Remove(0, CapImageFilePaths.CapImageFolderPath.Length), //FileName
                    SelectedPrimaryColor, //Primary Color
                    SelectedSecondaryColor); //Secondary Color

                //User can create duplicates
                savedBrands.Add(newBrand);
                savedBrands.SaveToBrandsFile();

                if (addCapView.IsActive)
                {
                    addCapView.UpdateBrandDropdown();

                    MessageBox.Show("Brand Created.  Please check Brand Dropdown in Add Cap Window.", "Brand Created", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
                TryClose();
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

            if (SelectedBrandImage == null || SelectedBrandImage == string.Empty)
            {
                MessageBox.Show("Brand must have an Image!", "Null Reference Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            if (SelectedPrimaryColor.A < 255 || SelectedPrimaryColor.A < 255)
            {
                MessageBox.Show("The Brand's colors must be fully opaque (No Transparency)!", "Invalid Information", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            return output;
        }
    }
}
