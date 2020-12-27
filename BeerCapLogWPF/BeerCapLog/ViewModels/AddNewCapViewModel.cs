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
        //TODO - Change Brand Dropdown wire up - TEST
        /// <summary>
        /// The Brands that will populate the Brand Dropdown Control.
        /// </summary>
        public BindableCollection<BrandModel> Brands { get; set; }
        /// <summary>
        /// All the possible qualities a Beer Cap can be in.
        /// </summary>
        public BindableCollection<Quality> PossibleQualities { get; set; }

        #region Selected Brand
        private BrandModel _selectedBrand;

        public BrandModel SelectedBrand
        {
            get { return _selectedBrand; }
            set { _selectedBrand = value; }
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
        /// <summary>
        /// The User's existing Beer Cap Collection.
        /// </summary>
        private List<BeerCapModel> userCollection = new List<BeerCapModel>();
        #endregion

        /// <summary>
        /// Creates a new instance of the Add New Cap View Window.
        /// </summary>
        /// <param name="userAddingCap">
        /// The User who wants to add a new Cap to their collection.
        /// </param>
        /// <param name="usersBeerCapCollection">
        /// The User's Beer Cap collection.
        /// </param>
        public AddNewCapViewModel (UserModel userAddingCap, List<BeerCapModel> usersBeerCapCollection)
        {
            //MockUserProcessor msp = new MockUserProcessor();

            user = userAddingCap;
            userCollection = usersBeerCapCollection;

            List<BrandModel> savedBrands = UtilityFilePaths.BrandModelsFile.FullFilePath().LoadFile().ConvertLinesIntoBrands();
            
            Brands = new BindableCollection<BrandModel>(savedBrands);

            PossibleQualities = new BindableCollection<Quality>((Quality[])Enum.GetValues(typeof(Quality)));

            SelectedAquireDate = DateTime.Today;
        }

        /// <summary>
        /// Tries to create a new cap through the Form Data.
        /// </summary>
        public void TryCreateCap()
        {
            if (ValidateFormData())
            {
                BeerCapModel newCap = new BeerCapModel
                (
                    userCollection.Count + 1,
                    SelectedBrand,
                    SelectedQuality,
                    SelectedAquireDate,
                    CreatedUnderMessage
                );

                userCollection.Add(newCap);

                userCollection.SaveCapCollectionToFile(user);

                BackToDataTable();
            }
        }

        /// <summary>
        /// Takes the User back to their DataTable.
        /// </summary>
        public void BackToDataTable()
        {
            manager.ShowWindow(new UserDataTableViewModel(user), null, null);
            TryClose();
        }

        public void GoToAddBrandWindow()
        {
            //TODO - Implement Go To Add Brand Window function.
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

            if (SelectedAquireDate > DateTime.Today)
            {
                MessageBox.Show("You cannot have acquired your Beer Cap from the future!", "Invalid Temporal Logging", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            return output;
        }
    }
}