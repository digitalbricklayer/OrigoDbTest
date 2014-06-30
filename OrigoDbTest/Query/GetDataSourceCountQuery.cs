using System.Linq;
using OrigoDB.Core;
using OrigoDbTest.Models;

namespace OrigoDbTest.Query
{
    class GetDataSourceCountQuery : Query<DataSourceModel,int>
    {
        public override int Execute(DataSourceModel model)
        {
            return model.DataSources.Count();
        }
    }
}