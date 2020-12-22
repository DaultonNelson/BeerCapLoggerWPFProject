using BeerCapLog.DataAccess;
using BeerCapLog.DataUtilities;
using BeerCapLog.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BeerCapLog.ViewModels
{
    //TODO - Cap Image Dropdown (Make grid or wider for content?)
    public class AddNewCapViewModel : Screen
    {
        #region Variables
        /// <summary>
        /// The Brands that will populate the Brand Dropdown Control.
        /// </summary>
        public BindableCollection<Brand> Brands { get; set; }
        /// <summary>
        /// All the possible qualities a Beer Cap can be in.
        /// </summary>
        public BindableCollection<Quality> PossibleQualities { get; set; }
        /// <summary>
        /// A collection of all the full file paths towards the Cap Images.
        /// </summary>
        public BindableCollection<string> CapImagePaths { get; set; }

        #region Selected Brand
        private Brand _selectedBrand;

        public Brand SelectedBrand
        {
            get { return _selectedBrand; }
            set { _selectedBrand = value; }
        }
        #endregion
        #region Selected Cap Path
        private string _selectedCapPath;

        public string SelectedCapPath
        {
            get { return _selectedCapPath; }
            set { _selectedCapPath = value; }
        } 
        #endregion
        #region Selected Quality
        private Quality _selectedQuality;

        public Quality SelectedQuality
        {
            get { return _selectedQuality; }
            set { _selectedQuality = value; }
        }
        #endregion
        #region Selected Aquire Date
        private DateTime _selectedAquireDate;

        public DateTime SelectedAquireDate
        {
            get { return _selectedAquireDate; }
            set { _selectedAquireDate = value; }
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
        #region Created Under Message
        private string _createdUnderMessage;

        public string CreatedUnderMessage
        {
            get { return _createdUnderMessage; }
            set { _createdUnderMessage = value; }
        } 
        #endregion
        
        /// <summary>
        /// Manages the Windows for Caliburn Micro.
        /// </summary>
        private IWindowManager manager = new WindowManager();
        /// <summary>
        /// The User adding a new Cap to their collection on this form.
        /// </summary>
        private UserModel user;
        #endregion

        /// <summary>
        /// Creates a new instance of the Add New Cap View Window.
        /// </summary>
        /// <param name="userAddingCap">
        /// The User who wants to add a new Cap to their collection.
        /// </param>
        public AddNewCapViewModel()//(UserModel userAddingCap)
        {
            //NOTE: Using a Mock User with Mock Data right now.

            MockUserProcessor msp = new MockUserProcessor();

            user = msp.GenerateMockUsers(1).First();

            //TODO - Populate Brands with Saved Brands or dummy brands.
            MockBeerCapProcessor mbcp = new MockBeerCapProcessor();

            #region Get Mock Brands
            List<Brand> sortedGeneratedBrands = new List<Brand>();

            for (int i = 0; i < 10; i++)
            {
                sortedGeneratedBrands.Add(mbcp.GenerateMockBrand(i + 1));
            }

            sortedGeneratedBrands.Sort();

            Brands = new BindableCollection<Brand>(sortedGeneratedBrands);
            #endregion

            #region Get Cap Image Paths
            List<string> fullCapPaths = new List<string>();

            for (int i = 0; i < CapImage.CapImageNames.Length; i++)
            {
                fullCapPaths.Add(CapImage.GetFullPathFromName(CapImage.CapImageNames[i]));
            }

            CapImagePaths = new BindableCollection<string>(fullCapPaths);

            SelectedCapPath = CapImagePaths[0];
            #endregion

            PossibleQualities = new BindableCollection<Quality>(mbcp.qualities);

            SelectedAquireDate = DateTime.Today;

            #region Initialize Selected Colors
            SelectedPrimaryColor = Color.FromArgb(255, 255, 255, 255);
            SelectedSecondaryColor = Color.FromArgb(255, 255, 255, 255); 
            #endregion
        }

        /// <summary>
        /// Tries to create a new cap through the Form Data.
        /// </summary>
        public void TryCreateCap()
        {
            if (ValidateFormData())
            {
                BeerCap newCap = new BeerCap
                (
                    user.BeerCaps.Count,
                    SelectedCapPath,
                    SelectedBrand,
                    SelectedQuality,
                    SelectedPrimaryColor,
                    SelectedSecondaryColor,
                    SelectedAquireDate,
                    CreatedUnderMessage
                );

                //TODO - Save Cap
                user.BeerCaps.Add(newCap);

                user.BeerCaps.SaveCapCollectionToFile(user);

                manager.ShowWindow(new UserDataTableViewModel(), null, null);
                TryClose();
            }
        }

        /// <summary>
        /// Check if the Form Data is valid.
        /// </summary>
        /// <returns></returns>
        private bool ValidateFormData()
        {
            bool output = true;

            if (SelectedBrand == null)
            {
                MessageBox.Show("The Cap must have a Brand!", "Null Reference Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            if (SelectedCapPath == null || SelectedCapPath == string.Empty)
            {
                MessageBox.Show("The Cap must have an Image associated with it!", "Null Reference Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            if (SelectedAquireDate > DateTime.Today)
            {
                MessageBox.Show("You cannot have acquired your Beer Cap from the future!", "Invalid Temporal Logging", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            //TODO - Check to make sure that the Colors have a full alpha.

            return output;
        }
    }
}