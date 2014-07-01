using System;
using OrigoDB.Core;
using OrigoDbTest.Models;

namespace OrigoDbTest.Query
{
    class GetDataSourceByIdQuery : Query<DataSourceModel, DataSource>
    {
        private readonly Guid identityToFind;

        public GetDataSourceByIdQuery(Guid theIdentity)
        {
            this.identityToFind = theIdentity;
        }

        public override DataSource Execute(DataSourceModel model)
        {
            if (!model.DataSources.ContainsKey(this.identityToFind))
                return null;
            return model.DataSources[this.identityToFind];
        }
    }
}
