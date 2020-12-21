using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCapLog.Models
{
    public class CapCollection<T> where T : BeerCap
    {
        #region Variables
        /// <summary>
        /// The List the Beer Caps will be held in.
        /// </summary>
        List<T> caps;

        /// <summary>
        /// The ID number assigned to this collection.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The count of Beer Caps within this collection.
        /// </summary>
        public int Count { get { return caps.Count; } }
        #endregion

        /// <summary>
        /// Creates a new Beer Cap Collection.
        /// </summary>
        /// <param name="intendedCollectionIndex">
        /// The intended index for this Beer Cap Collection.
        /// </param>
        public CapCollection(int intendedCollectionIndex)
        {
            Id = intendedCollectionIndex;
            caps = new List<T>();
        }

        /// <summary>
        /// Creates a new Beer Cap Collection.
        /// </summary>
        /// <param name="intendedCollectionIndex">
        /// The intended index for this Beer Cap Collection.
        /// </param>
        /// <param name="alreadyExistingCollection">
        /// An already existing collection to fill this Collection with.
        /// </param>
        public CapCollection(int intendedCollectionIndex, List<T> alreadyExistingCollection)
        {
            Id = intendedCollectionIndex;
            caps = alreadyExistingCollection;
        }

        /// <summary>
        /// Add to this Beer Cap Collection.
        /// </summary>
        /// <param name="capToAdd">
        /// The Beer Cap to add to this Beer Cap Collection.
        /// </param>
        public void Add(T capToAdd)
        {
            caps.Add(capToAdd);
        }
    }
}