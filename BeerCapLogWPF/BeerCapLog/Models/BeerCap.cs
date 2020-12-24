using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BeerCapLog.Models
{
    public class BeerCap : IComparable<BeerCap>
    {
        #region Properties
        /// <summary>
        /// The identification number of this Beer Cap.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The path to this Cap's Image.
        /// </summary>
        public string CapImagePath { get; set; }
        /// <summary>
        /// The brand name associated with this.
        /// </summary>
        public string CapBrandName { get; set; }
        /// <summary>
        /// The condition this cap is in.
        /// </summary>
        public Quality CapQuality { get; set; }
        /// <summary>
        /// The primary color of this cap.
        /// </summary>
        public Color PrimaryCapColor { get; set; }
        /// <summary>
        /// The secondary color of this cap.
        /// </summary>
        public Color SecondaryCapColor { get; set; }
        /// <summary>
        /// The date this Cap was acquired.
        /// </summary>
        public DateTime DateAquired { get; set; }
        /// <summary>
        /// The message that appears under this cap.
        /// </summary>
        public string UnderCapMessage { get; set; }

        /// <summary>
        /// The Primary Color converted to a string.
        /// </summary>
        public string PrimaryColorString { get { return PrimaryCapColor.ToString(); } }
        /// <summary>
        /// The Secondary Color converted to a string.
        /// </summary>
        public string SecondaryColorString { get { return SecondaryCapColor.ToString(); } }
        #endregion

        /// <summary>
        /// Creates a new Beer Cap.
        /// </summary>
        /// <param name="_id">The ID number of this Beer Cap</param>
        /// <param name="_capPath">The path to this Beer Cap's Image</param>
        /// <param name="_brandName">The Brand of this Beer Cap</param>
        /// <param name="_quality">The Quality of this Beer Cap</param>
        /// <param name="_primary">The Primary Color of this Beer Cap</param>
        /// <param name="_secondary">The Secondary Color of this Beer Cap</param>
        /// <param name="_date">The Acquisiton Date of this Beer Cap</param>
        /// <param name="_underCap">The massge displayed under this Beer Cap</param>
        public BeerCap(int _id, string _capPath, string _brandName, Quality _quality, Color _primary, Color _secondary, DateTime _date, string _underCap)
        {
            Id = _id;
            CapImagePath = _capPath;
            CapBrandName = _brandName;
            CapQuality = _quality;
            PrimaryCapColor = _primary;
            SecondaryCapColor = _secondary;
            DateAquired = _date;

            if (_underCap == string.Empty || _underCap == null)
            {
                UnderCapMessage = "[None]";
                return;
            }

            UnderCapMessage = _underCap;
        }

        //Comparing by ID
        public int CompareTo(BeerCap other)
        {
            int output = 5;

            output = Id.CompareTo(other.Id);

            return output;
        }
    }
}