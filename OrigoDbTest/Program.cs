using System;
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
            var config = EngineConfiguration.Create()
                                            .ForIsolatedTest();
            var theEngine = Engine.Create<DataSourceModel>(config);

            // Write some data
            var temperatureDataSourceId = Guid.NewGuid();
            theEngine.Execute(new AddDataSourceCommand("Office temperature", temperatureDataSourceId));
            theEngine.Execute(new AddDataSourceCommand("Office humidity", Guid.NewGuid()));

            theEngine.Close();

            // Re-load the database
            theEngine = Engine.Load<DataSourceModel>(config);

            // Retrieve the data...
            var dataSourceCount = theEngine.Execute(new GetDataSourceCountQuery());

            Console.WriteLine("Found {0} data sources.", dataSourceCount);

            var temperatureDataSourceQuery = new GetDataSourceByIdQuery(temperatureDataSourceId);
            var officeTemperatureDataSource = theEngine.Execute(temperatureDataSourceQuery);

            if (officeTemperatureDataSource != null)
                Console.WriteLine("Found '{0}' data source.", officeTemperatureDataSource.Name);
            else
                Console.WriteLine("Unable to find '{0}'.", temperatureDataSourceId);

            Console.WriteLine("Press [Enter] to quit.");
            Console.ReadLine();

            theEngine.Close();
        }
    }
}
 