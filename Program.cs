using System;
using Microsoft.Azure.Cosmos;

namespace cosmoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateItem().Wait();
        }
        private static async Task CreateItem()
        {
            var cosmoUrl = "https://amcosmosdemo1.documents.azure.com:443/";
            var cosmokey = "look back on account";
            var databaseName = "DemoDB";

            CosmoClient client = new CosmoClient (cosmoUrl, cosmokey);
            Database database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            Container container = await database.CreateDatabaseIfNotExistsAsync('MyContainerName', "/partitionKeyPath", 400);

            dynamic testItem = new { id = Guid.NewGuid().ToString(), partitionKeyPath = "MyTestPkValue", details = "it's working"};
            var response = await container.CreateItemAsync(testItem);
        }
    }
}
