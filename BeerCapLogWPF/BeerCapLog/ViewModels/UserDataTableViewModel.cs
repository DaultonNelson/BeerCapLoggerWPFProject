using BeerCapLog.DataAccess;
using BeerCapLog.DataUtilities;
using BeerCapLog.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.ViewModels
{
    //TODO - Some way is needed to delete existing caps in collection
    public class UserDataTableViewModel : Screen
    {
        #region Variables
        /// <summary>
        /// The Collection of Caps collected by the user.
        /// </summary>
        public BindableCollection<BeerCap> CollectedCaps { get; set; }

        /// <summary>
        /// The Header of the window.
        /// </summary>
        public string HeaderText { get; }

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

            HeaderText = $"{dataTableUser.FirstName} {dataTableUser.LastName}'s Caps";
            
            //MockBeerCapProcessor mbcp = new MockBeerCapProcessor();

            List<BeerCap> sortedCapCollection = dataTableUser.GetSavedBeerCapCollection();
            sortedCapCollection.Sort();

            CollectedCaps = new BindableCollection<BeerCap>(sortedCapCollection);
        }

        /// <summary>
        /// Adds a new Cap to the User's collection.
        /// </summary>
        public void AddNewCapForUser()
        {
            manager.ShowWindow(new AddNewCapViewModel(dataTableUser, CollectedCaps.ToList()), null, null);
            TryClose();
        }
    }
}