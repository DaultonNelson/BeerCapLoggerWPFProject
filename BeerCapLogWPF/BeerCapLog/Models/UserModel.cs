using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.Models
{
    //TODO - Add Last Time Logged in
    public class UserModel : IComparable<UserModel>
    {
        #region Properties
        /// <summary>
        /// The identification number of this User.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The First Name of the User.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The Last Name of the User.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The Date of Birth for this User.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// The time this User last logged in.
        /// </summary>
        public DateTime TimeLastLoggedIn { get; set; }
        /// <summary>
        /// The date this User joined the Program.
        /// </summary>
        public DateTime DateJoined { get; set; }

        /// <summary>
        /// The full name of this User.
        /// </summary>
        public string FullName {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        /// <summary>
        /// A readable Birthday string for the User.
        /// </summary>
        public string ReadableBirthday {
            get
            {
                return DateOfBirth.ToShortDateString();
            }
        }
        #endregion

        /// <summary>
        /// Creates a new User.
        /// </summary>
        /// <param name="_id">The ID of the User</param>
        /// <param name="_firstName">The First Name of the User</param>
        /// <param name="_lastName">The Last Name of the User</param>
        /// <param name="_birthday">The Birthday of the User</param>
        /// <param name="_lastLogin">The time the User last logged in</param>
        public UserModel(int _id, string _firstName, string _lastName, DateTime _birthday, DateTime _lastLogin)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            DateOfBirth = _birthday;
            DateJoined = DateTime.Now;
            TimeLastLoggedIn = _lastLogin;
        }

        /// <summary>
        /// Creates a new User.
        /// </summary>
        /// <param name="_id">The ID of the User</param>
        /// <param name="_firstName">The First Name of the User</param>
        /// <param name="_lastName">The Last Name of the User</param>
        /// <param name="_birthday">The Birthday of the User</param>
        /// <param name="_lastLogin">The time the User last logged in</param>
        /// <param name="_joined">The date the User joined this app</param>
        public UserModel(int _id, string _firstName, string _lastName, DateTime _birthday, DateTime _lastLogin, DateTime _joined)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            DateOfBirth = _birthday;
            DateJoined = _joined;
            TimeLastLoggedIn = _lastLogin;
        }
        
        //Comparing by Time last joined
        public int CompareTo(UserModel other)
        {
            int output = 5;

            output = TimeLastLoggedIn.CompareTo(other.TimeLastLoggedIn);

            return output;
        }
    }
}