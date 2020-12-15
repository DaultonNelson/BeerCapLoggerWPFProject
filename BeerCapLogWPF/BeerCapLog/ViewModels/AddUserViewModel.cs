using BeerCapLog.DataAccess;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.ViewModels
{
    public class AddUserViewModel : Screen
    {
        #region Variables
        public string RightCapImage { get; set; }

        Random rnd = new Random();
        #endregion

        public AddUserViewModel()
        {
            RightCapImage = CapImage.GetFullPathFromName(GetRandomItem<string>(CapImage.CapImageNames.ToArray()));
        }

        //TODO - Make this it's own thing, currently being repeated
        public T GetRandomItem<T>(T[] data)
        {
            return data[rnd.Next(0, data.Length)];
        }
    }
}