using System;
using OrigoDB.Core;
using OrigoDbTest.Models;

namespace OrigoDbTest.Commands
{
    [Serializable]
    class AddDataSourceCommand : Command<DataSourceModel>
    {
        private readonly string newName;
        private readonly Guid newIdentity;

        public AddDataSourceCommand(string dataSourceName, Guid theIdentity)
        {
            this.newName = dataSourceName;
            this.newIdentity = theIdentity;
        }

        public override void Execute(DataSourceModel theDataSourceModel)
        {
            var newDataSource = new DataSource
            {
                Name = this.newName, 
                Id = newIdentity
            };
            theDataSourceModel.AddDataSource(newDataSource);
        }
    }
}
