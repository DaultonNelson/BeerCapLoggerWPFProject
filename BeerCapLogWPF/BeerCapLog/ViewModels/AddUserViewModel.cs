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
    public class AddUserViewModel : Screen
    {
        #region Variables
        /// <summary>
        /// The property for the Beer Cap Image displayed on the right side of the screen.
        /// </summary>
        public string RightCapImage { get; set; }

        #region UserFirstName
        private string _userFirstName;

        public string UserFirstName
        {
            get { return _userFirstName; }
            set { _userFirstName = value; }
        }
        #endregion
        #region UserLastName
        private string _userLastName;

        public string UserLastName
        {
            get { return _userLastName; }
            set { _userLastName = value; }
        }
        #endregion
        #region UserDateOfBirth
        private DateTime _userDateOfBirth;

        public DateTime UserDateOfBirth
        {
            get { return _userDateOfBirth; }
            set { _userDateOfBirth = value; }
        }
        #endregion

        /// <summary>
        /// The date where someone is considered an adult.
        /// </summary>
        private DateTime adultDate = DateTime.Today;
        /// <summary>
        /// Manages the Windows for Caliburn Micro
        /// </summary>
        private IWindowManager manager = new WindowManager();
        /// <summary>
        /// A List of Users that were loaded from the Shell View window.
        /// </summary>
        private List<UserModel> usersLoadedFromShell = new List<UserModel>();
        #endregion

        public AddUserViewModel(List<UserModel> shellUsers)
        {
            adultDate = adultDate.AddYears(-18);
            //MessageBox.Show(adultDate.ToShortDateString(), "Date", MessageBoxButton.OK);
            usersLoadedFromShell = shellUsers;

            RandomPicking rp = new RandomPicking();

            //TODO - Replace this Right Cap Image with something.
            RightCapImage = CapImageFilePaths.GetFullPathFromName(
                rp.GetRandomItem<string>(CapImageFilePaths.CapImageNames));

            UserDateOfBirth = DateTime.Today;
        }

        /// <summary>
        /// Adds a User based on the typed in form data.
        /// </summary>
        public void AddUserWithFormData()
        {
            //MessageBox.Show($"{UserFirstName} {UserLastName}: {UserDateOfBirth}", "Test", MessageBoxButton.OK);

            if (ValidateFromData())
            {
                //List<UserModel> users = new List<UserModel>();

                UserModel newUser = new UserModel(
                    usersLoadedFromShell.Count + 1,
                    UserFirstName,
                    UserLastName,
                    UserDateOfBirth,
                    DateTime.Now
                );

                usersLoadedFromShell.Add(newUser);

                usersLoadedFromShell.SaveToUsersFile();

                BackToShell();
            }
        }

        /// <summary>
        /// Takes the User back to the Shell View.
        /// </summary>
        public void BackToShell()
        {
            manager.ShowWindow(new ShellViewModel(), null, null);
            TryClose();
        }

        /// <summary>
        /// Validates the Add User form data.
        /// </summary>
        /// <returns>
        /// True if data is valid, or false if not.
        /// </returns>
        private bool ValidateFromData()
        {
            bool output = true;

            if (UserFirstName == string.Empty || UserFirstName == null)
            {
                MessageBox.Show("First Name must have a value.", "Empty Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            if (UserLastName == string.Empty || UserLastName == null)
            {
                MessageBox.Show("Last Name must have a value.", "Empty Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            if (UserDateOfBirth > adultDate)
            {
                MessageBox.Show("User must be 18 years or older.", "Underage Error", MessageBoxButton.OK, MessageBoxImage.Error);
                output = false;
            }

            return output;
        }
    }
}