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
        /// The brand this Cap belongs to.
        /// </summary>
        public Brand CapBrand { get; set; }
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
        /// The message that appears under this cap.
        /// </summary>
        public string UnderCapMessage { get; set; }
        #endregion

        /// <summary>
        /// Creates a new Beer Cap.
        /// </summary>
        /// <param name="_id">The ID number of this Beer Cap</param>
        /// <param name="_capPath">The path to this Beer Cap's Image</param>
        /// <param name="_brand">The Brand of this Beer Cap</param>
        /// <param name="_quality">The Quality of this Beer Cap</param>
        /// <param name="_primary">The Primary Color of this Beer Cap</param>
        /// <param name="_secondary">The Secondary Color of this Beer Cap</param>
        /// <param name="_underCap">The massge displayed under this Beer Cap</param>
        public BeerCap(int _id, string _capPath, Brand _brand, Quality _quality, Color _primary, Color _secondary, string _underCap)
        {
            Id = _id;
            CapImagePath = _capPath;
            CapBrand = _brand;
            CapQuality = _quality;
            PrimaryCapColor = _primary;
            SecondaryCapColor = _secondary;

            if (_underCap == string.Empty)
            {
                UnderCapMessage = "[None]";
                return;
            }

            UnderCapMessage = _underCap;
        }

        public int CompareTo(BeerCap other)
        {
            int output = 5;

            output = Id.CompareTo(other.Id);

            return output;
        }
    }
}