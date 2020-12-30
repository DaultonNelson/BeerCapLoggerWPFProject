using BeerCapLog.DataUtilities;
using BeerCapLog.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeerCapLog.ViewModels
{
    public class UserDataTableViewModel : Screen
    {
        #region Variables
        /// <summary>
        /// A collection containing the User's collected Beer Caps.
        /// </summary>
        public BindableCollection<BeerCapModel> CollectedCaps { get; set; }

        /// <summary>
        /// The Header of the window.
        /// </summary>
        public string HeaderText { get; }

        #region Selected Grid Item
        private BeerCapModel _selectedGridItem;

        public BeerCapModel SelectedGridItem
        {
            get { return _selectedGridItem; }
            set { _selectedGridItem = value; }
        } 
        #endregion

        /// <summary>
        /// Manages the Windows for Caliburn Micro
        /// </summary>
        private IWindowManager manager = new WindowManager();
        /// <summary>
        /// The User this Data Table is based off of.
        /// </summary>
        private UserModel dataTableUser;
        #endregion

        /// <summary>
        /// Creates a new instance of the User Data Table View Window.
        /// </summary>
        /// <param name="userToLoadFrom">
        /// The User the window pulls information from.
        /// </param>
        public UserDataTableViewModel(UserModel userToLoadFrom)
        {
            dataTableUser = userToLoadFrom;

            HeaderText = $"{dataTableUser.FullName}'s Caps";
            
            //MockBeerCapProcessor mbcp = new MockBeerCapProcessor();

            List<BeerCapModel> sortedCapCollection = dataTableUser.GetSavedBeerCapCollection();
            sortedCapCollection.Sort();

            CollectedCaps = new BindableCollection<BeerCapModel>(sortedCapCollection);
        }

        /// <summary>
        /// Adds a new Cap to the User's collection.
        /// </summary>
        public void AddNewCapForUser()
        {
            manager.ShowWindow(new AddNewCapViewModel(dataTableUser, CollectedCaps.ToList()), null, null);
            TryClose();
        }

        /// <summary>
        /// Removes the User selected Beer Cap from their collection.
        /// </summary>
        public void RemoveSelectedCap()
        {
            if (SelectedGridItem == null)
            {
                MessageBox.Show("Please select a Beer Cap.", "Non-Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(MessageBox.Show($"Do you want to Remove Beer Cap #{SelectedGridItem.Id} from your collection?", "Remove Cap From Collection?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                CollectedCaps.RemoveAt(SelectedGridItem.Id - 1);
                UpdateBeerCapIds();
                CollectedCaps.ToList().SaveCapCollectionToFile(dataTableUser);

                MessageBox.Show("Beer Cap Removed", "Removed", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Removes the User from the application.
        /// </summary>
        public void RemoveUser()
        {
            if (MessageBox.Show($"Are you sure you want to delete {dataTableUser.FullName}'s Profile?", "Remove User?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                if (dataTableUser.DeleteUserProfile())
                {
                    MessageBox.Show("User has been removed from application.", "User Removed", MessageBoxButton.OK, MessageBoxImage.Information);

                    manager.ShowWindow(new ShellViewModel(), null, null);
                    TryClose(); 
                }
            }
        }

        /// <summary>
        /// Updates the Beer Cap IDs in the User's collection.
        /// </summary>
        private void UpdateBeerCapIds()
        {
            for (int i = 0; i < CollectedCaps.Count; i++)
            {
                CollectedCaps[i].Id = i + 1;
            }
        }
    }
}