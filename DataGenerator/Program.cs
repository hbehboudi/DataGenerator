using DataGenerator.Configurations;
using Nest;
using System;
using System.Configuration;

namespace DataGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var url = new Uri(ConfigurationManager.AppSettings["ElasticUrl"]);
            var indexName = ConfigurationManager.AppSettings["ElasticIndexName"];
            var settings = new ConnectionSettings(url).DefaultIndex(indexName);
            var client = new ElasticClient(settings);

            var writeConfig = new WriteConfig()
            {
                CardBulkSize = 100_000,
                TransactionBulkSize = 100_000,
                NumberOfCardBulk = 1,
                NumberOfTransactionBulk = 1
            };

            var importer = new Importer(writeConfig);
            importer.Import(client);
        }
    }
}
