using BeerCapLog.DataAccess;
using BeerCapLog.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        public ShellViewModel()
        {
            MockUserProcessor tsda = new MockUserProcessor();

            List<UserModel> sortedUsersByBirth = tsda.GenerateMockUsers(11);
            sortedUsersByBirth.Sort();
            sortedUsersByBirth.Reverse();

            Users = new BindableCollection<UserModel>(sortedUsersByBirth);
        }
    }
}