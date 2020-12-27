using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BeerCapLog.Models
{
    public class BeerCapModel : IComparable<BeerCapModel>, INotifyPropertyChanged
    {
        #region Properties
        /// <summary>
        /// The event that fires off when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region ID
        private int _id;

        /// <summary>
        /// The identification number of this Beer Cap.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        } 
        #endregion

        /// <summary>
        /// The Brand Model associated with this Beer Cap.
        /// </summary>
        public BrandModel CapBrand { get; set; }
        /// <summary>
        /// The condition this Beer Cap is in.
        /// </summary>
        public Quality CapQuality { get; set; }
        /// <summary>
        /// The date this Beer Cap was acquired.
        /// </summary>
        public DateTime DateAquired { get; set; }
        /// <summary>
        /// The message that appears under this Beer Cap.
        /// </summary>
        public string UnderCapMessage { get; set; }
        #endregion

        /// <summary>
        /// Creates a new Beer Cap.
        /// </summary>
        /// <param name="_id">The ID number of this Beer Cap</param>
        /// <param name="_brand">The brandof this Beer Cap</param>
        /// <param name="_quality">The Quality of this Beer Cap</param>
        /// <param name="_date">The Acquisiton Date of this Beer Cap</param>
        /// <param name="_underCap">The massge displayed under this Beer Cap</param>
        public BeerCapModel(int _id, BrandModel _brand, Quality _quality, DateTime _date, string _underCap)
        {
            Id = _id;
            CapBrand = _brand;
            CapQuality = _quality;
            DateAquired = _date;

            if (_underCap == string.Empty || _underCap == null)
            {
                UnderCapMessage = "[None]";
                return;
            }

            UnderCapMessage = _underCap;
        }

        //Comparing by ID
        public int CompareTo(BeerCapModel other)
        {
            int output = 5;

            output = Id.CompareTo(other.Id);

            return output;
        }

        //For notification of property change
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}