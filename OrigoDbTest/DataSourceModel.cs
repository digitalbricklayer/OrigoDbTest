using System;
using System.Collections.Generic;
using OrigoDB.Core;

namespace OrigoDbTest
{
    [Serializable]
    class DataSourceModel : Model
    {
        public DataSourceModel()
        {
            this.DataSources = new List<DataSource>();
        }

        public List<DataSource> DataSources { get; private set; }

        public void AddDataSource(string theDataSourceName)
        {
            this.DataSources.Add(new DataSource{Name = theDataSourceName});
        }

        public void AddDataSource(DataSource theDataSource)
        {
            this.DataSources.Add(theDataSource);
        }
    }

    [Serializable]
    class DataSource : ICloneable
    {
        public string Name { get; set; }

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
