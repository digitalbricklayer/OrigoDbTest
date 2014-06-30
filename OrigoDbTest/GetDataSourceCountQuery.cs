using System.Linq;
using OrigoDB.Core;

namespace OrigoDbTest
{
    class GetDataSourceCountQuery : Query<DataSourceModel,int>
    {
        public override int Execute(DataSourceModel model)
        {
            return model.DataSources.Count();
        }
    }
}