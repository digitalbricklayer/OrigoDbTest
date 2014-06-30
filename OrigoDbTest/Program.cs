using System;
using OrigoDB.Core;
using OrigoDB.Core.Test;

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
            Console.WriteLine("Press [Enter] to quit.");
            Console.ReadLine();

            theEngine.Close();
        }
    }
}
