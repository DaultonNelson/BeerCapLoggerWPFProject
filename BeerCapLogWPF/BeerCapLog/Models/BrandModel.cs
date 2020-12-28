using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BeerCapLog.Models
{
    public class BrandModel : IComparable<BrandModel>
    {
        #region Variables
        /// <summary>
        /// The unique indentifying number of this Brand.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of this Brand.
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// The file name associated with the Brand Image file.
        /// </summary>
        public string BrandImageFileName { get; set; }
        /// <summary>
        /// The primary color of this Brand.
        /// </summary>
        public Color PrimaryColor { get; set; }
        /// <summary>
        /// The secondary color of this Brand.
        /// </summary>
        public Color SecondaryColor { get; set; }

        /// <summary>
        /// The Primary Color converted to a string.
        /// </summary>
        public string PrimaryColorString { get { return PrimaryColor.ToString(); } }
        /// <summary>
        /// The Secondary Color converted to a string.
        /// </summary>
        public string SecondaryColorString { get { return SecondaryColor.ToString(); } } 
        #endregion

        /// <summary>
        /// Creates a new instance of a Brand.
        /// </summary>
        /// <param name="_id">The ID of the Brand</param>
        /// <param name="_name">The name of the Brand</param>
        /// <param name="_fileName">The file name of the Brand Image</param>
        /// <param name="_primary">The Primary Color of the Brand</param>
        /// <param name="_secondary">The Secondy Color of the Brand Image</param>
        public BrandModel(int _id, string _name, string _fileName, Color _primary, Color _secondary)
        {
            Id = _id;
            BrandName = _name;
            BrandImageFileName = _fileName;
            PrimaryColor = _primary;
            SecondaryColor = _secondary;
        }

        //Comparing by Name
        public int CompareTo(BrandModel other)
        {
            int output = 5;

            output = BrandName.CompareTo(other.BrandName);

            return output;
        }
    }
}