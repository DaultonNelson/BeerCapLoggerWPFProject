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

namespace BeerCapLog.ViewModels
{
    public class ShellViewModel : Screen
    {
        #region Variables
        /// <summary>
        /// The Users saved to this application.
        /// </summary>
        public BindableCollection<UserModel> Users { get; set; }

        #region Selected User
        private UserModel _selectedUser;

        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; }
        }
        #endregion

        /// <summary>
        /// Manages the Windows for Caliburn Micro
        /// </summary>
        private IWindowManager manager = new WindowManager();
        /// <summary>
        /// A list of the Created Users sorted by their birthdays (Youngest to Oldest).
        /// </summary>
        private List<UserModel> sortedUsersByBirth = new List<UserModel>();
        #endregion

        public ShellViewModel()
        {
            MockUserProcessor tsda = new MockUserProcessor();

            //sortedUsersByBirth = tsda.GenerateMockUsers(11);
            sortedUsersByBirth = UtilityFilePaths.UserModelsFile.FullFilePath().LoadFile().ConvertLinesIntoUsers();
            sortedUsersByBirth.Sort();
            sortedUsersByBirth.Reverse();

            Users = new BindableCollection<UserModel>(sortedUsersByBirth);
        }

        /// <summary>
        /// The function for the Start Here button used to add a new user.
        /// </summary>
        public void StartNewUserHere()
        {
            manager.ShowWindow(new AddUserViewModel(sortedUsersByBirth), null, null);
            TryClose();
        }

        /// <summary>
        /// The function for the User Dropdown when the user selects somethign from it.
        /// </summary>
        public void UserPickedFromDropdown()
        {
            manager.ShowWindow(new UserDataTableViewModel(), null, null);
            TryClose();
        }
    }
}