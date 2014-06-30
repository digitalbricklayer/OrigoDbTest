using System;
using System.Linq;
using OrigoDB.Core;
using OrigoDB.Core.Test;
using OrigoDbTest.Commands;
using OrigoDbTest.Models;
using OrigoDbTest.Query;

namespace OrigoDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a database
            var config = EngineConfiguration.Create().ForIsolatedTest();
            var theEngine = Engine.Create<DataSourceModel>(config);

            // Write some data
            theEngine.Execute(new AddDataSourceCommand("Jack"));

            theEngine.Close();

            // Retrieve the data
            theEngine = Engine.Load<DataSourceModel>(config);
            var dataSourceCount = theEngine.Execute(new GetDataSourceCountQuery());

            Console.WriteLine("Found {0} data sources.", dataSourceCount);

            const string dataSourceToFind = "Jack";
            var dataSource = theEngine.Execute(new GetDataSourceByNameQuery(dataSourceToFind));

            if (dataSource != null)
                Console.WriteLine("Found {0} data source.", dataSource.Name);
            else
                Console.WriteLine("Unable to find {0}.", dataSourceToFind);

            Console.WriteLine("Press [Enter] to quit.");
            Console.ReadLine();

            theEngine.Close();
        }
    }

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
