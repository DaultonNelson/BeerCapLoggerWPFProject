using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.Models
{
    public class BeerCap
    {
        #region Properties
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

        public BeerCap()
        {
            PrimaryCapColor = Color.FromName("White");
        }
    }
}