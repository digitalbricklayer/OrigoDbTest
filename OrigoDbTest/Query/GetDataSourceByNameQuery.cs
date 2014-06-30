using System.Linq;
using OrigoDB.Core;
using OrigoDbTest.Models;

namespace OrigoDbTest.Query
{
    class GetDataSourceByNameQuery : Query<DataSourceModel, DataSource>
    {
        private readonly string dataSourceName;

        public GetDataSourceByNameQuery(string theDataSourceName)
        {
            this.dataSourceName = theDataSourceName;
        }

        public override DataSource Execute(DataSourceModel model)
        {
            return model.DataSources.FirstOrDefault(ds => ds.Name == this.dataSourceName);
        }
    }
}