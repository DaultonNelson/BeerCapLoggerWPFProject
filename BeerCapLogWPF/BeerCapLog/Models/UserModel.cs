using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.Models
{
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
        /// The Beer Caps this User has logged.
        /// </summary>
        public List<BeerCap> BeerCaps { get; set; }
        /// <summary>
        /// The Date of Birth for this User.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
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
        /// <param name="_caps">The User's Beer Cap collection</param>
        /// <param name="_birthday">The Birthday of the User</param>
        public UserModel(int _id, string _firstName, string _lastName, List<BeerCap> _caps, DateTime _birthday)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            BeerCaps = _caps;
            DateOfBirth = _birthday;
            DateJoined = DateTime.Now;
        }

        /// <summary>
        /// Creates a new User.
        /// </summary>
        /// <param name="_id">The ID of the User</param>
        /// <param name="_firstName">The First Name of the User</param>
        /// <param name="_lastName">The Last Name of the User</param>
        /// <param name="_caps">The User's Beer Cap collection</param>
        /// <param name="_birthday">The Birthday of the User</param>
        /// <param name="_joined">The date the User joined this app</param>
        public UserModel(int _id, string _firstName, string _lastName, List<BeerCap> _caps, DateTime _birthday, DateTime _joined)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            BeerCaps = _caps;
            DateOfBirth = _birthday;
            DateJoined = _joined;
        }
        
        //Comparing by ID
        public int CompareTo(UserModel other)
        {
            int output = 5;

            output = Id.CompareTo(other.Id);

            return output;
        }
    }
}