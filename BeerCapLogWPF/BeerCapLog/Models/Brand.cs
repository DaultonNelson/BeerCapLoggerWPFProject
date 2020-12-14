using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.Models
{
    public class Brand : IComparable<Brand>
    {
        #region Properties
        /// <summary>
        /// The identification number of this Brand.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the Brand.
        /// </summary>
        public string Name { get; set; }
        #endregion

        /// <summary>
        /// Creates a new Brand.
        /// </summary>
        /// <param name="_id">The ID number of this Brand.</param>
        /// <param name="_name">The name of this Brand.</param>
        public Brand(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        public int CompareTo(Brand other)
        {
            int output = 5;

            output = Name.CompareTo(other.Name);

            return output;
        }
    }
}