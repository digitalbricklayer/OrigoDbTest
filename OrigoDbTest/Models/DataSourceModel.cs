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
            this.DataSources = new Dictionary<Guid, DataSource>();
        }

        public Dictionary<Guid, DataSource> DataSources { get; private set; }

        public void AddDataSource(DataSource theDataSource)
        {
            this.DataSources.Add(theDataSource.Id, theDataSource);
        }
    }
}
