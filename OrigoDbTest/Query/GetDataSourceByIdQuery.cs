using System;
using System.Linq;
using OrigoDB.Core;
using OrigoDbTest.Models;

namespace OrigoDbTest.Query
{
    class GetDataSourceByIdQuery : Query<DataSourceModel, DataSource>
    {
        private readonly Guid identityToFind;

        public GetDataSourceByIdQuery(Guid theIdentifier)
        {
            this.identityToFind = theIdentifier;
        }

        public override DataSource Execute(DataSourceModel model)
        {
            return model.DataSources.FirstOrDefault(sp => sp.Id == identityToFind);
        }
    }
}