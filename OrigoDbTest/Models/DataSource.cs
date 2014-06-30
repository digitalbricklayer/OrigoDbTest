using System;

namespace OrigoDbTest.Models
{
    [Serializable]
    class DataSource : ICloneable
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}