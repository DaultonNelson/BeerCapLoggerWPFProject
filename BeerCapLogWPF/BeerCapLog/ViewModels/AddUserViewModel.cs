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

//TODO - Load Existing User list into this window for saving.
namespace BeerCapLog.ViewModels
{
    public class AddUserViewModel : Screen
    {
        #region Variables
        IWindowManager manager = new WindowManager();

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
        DateTime adultDate = DateTime.Today;
        #endregion

        public AddUserViewModel()
        {
            adultDate = adultDate.AddYears(-18);
            //MessageBox.Show(adultDate.ToShortDateString(), "Date", MessageBoxButton.OK);

            RandomPicking rp = new RandomPicking();

            RightCapImage = CapImage.GetFullPathFromName(
                rp.GetRandomItem<string>(CapImage.CapImageNames.ToArray()));

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
                //TODO - Save User to files, and ! feed that to Shell View !

                List<UserModel> users = new List<UserModel>();

                UserModel newUser = new UserModel(
                    users.Count + 1,
                    UserFirstName,
                    UserLastName,
                    UserDateOfBirth
                    //TODO - Save a new List of Beer Cap to this user.
                );

                users.Add(newUser);

                users.SaveToUsersFile();

                manager.ShowWindow(new ShellViewModel(), null, null);
                TryClose();
            }
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

            if (UserFirstName == string.Empty || UserLastName == null)
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