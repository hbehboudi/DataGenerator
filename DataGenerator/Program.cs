using DataGenerator.Configurations;
using Nest;
using System;

namespace DataGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var url = new Uri("http://localhost:9200/");
            var settings = new ConnectionSettings(url).DefaultIndex("visual_query_framework_test_2");
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
