using System;
using OrigoDB.Core;
using OrigoDbTest.Models;

namespace OrigoDbTest.Commands
{
    [Serializable]
    class AddDataSourceCommand : Command<DataSourceModel>
    {
        private string newName;

        public AddDataSourceCommand(string dataSourceName)
        {
            this.newName = dataSourceName;
        }

        public override void Execute(DataSourceModel theDataSourceModel)
        {
            theDataSourceModel.AddDataSource(new DataSource{Name = this.newName});
        }
    }
}
