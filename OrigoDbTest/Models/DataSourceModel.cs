using System;
using System.Collections.Generic;
using OrigoDB.Core;

namespace OrigoDbTest.Models
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
}
