using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.Models
{
    public class Brand
    {
        /// <summary>
        /// The identification number of this Brand.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the brand.
        /// </summary>
        public string Name { get; set; }
    }
}