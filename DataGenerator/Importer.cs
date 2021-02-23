using DataGenerator.Configurations;
using DataGenerator.Generators;
using DataGenerator.Models;
using Nest;
using System.Collections.Generic;

namespace DataGenerator
{
    internal class Importer
    {
        private readonly WriteConfig writeConfig;
        private readonly CardGenerator cardGenerator;
        private readonly TransactionGenerator transactionGenerator;

        public Importer(WriteConfig writeConfig)
        {
            this.writeConfig = writeConfig;
            cardGenerator = new CardGenerator();
            transactionGenerator = new TransactionGenerator(writeConfig.NumberOfCardBulk * writeConfig.CardBulkSize);
        }

        public void Import(ElasticClient client)
        {
            for (int i = 0; i < writeConfig.NumberOfCardBulk; i++)
            {
                var cards = cardGenerator.GetCards(writeConfig.CardBulkSize);
                InsertCards(cards, client);
            }

            for (int i = 0; i < writeConfig.NumberOfTransactionBulk; i++)
            {
                var transactions = transactionGenerator.GetTransactions(writeConfig.TransactionBulkSize);
                InsertTransactions(transactions, client);
            }
        }

        private void InsertCards(IEnumerable<Card> cards, ElasticClient client)
        {
            var descriptor = new BulkDescriptor();

            foreach (var card in cards)
            {
                descriptor.Create<Card>(op => op.Document(card));
            }

            var result = client.Bulk(descriptor);
        }

        private void InsertTransactions(IEnumerable<Transaction> transactions, ElasticClient client)
        {
            var descriptor = new BulkDescriptor();

            foreach (var transaction in transactions)
            {
                descriptor.Create<Transaction>(op => op.Document(transaction));
            }

            var result = client.Bulk(descriptor);
        }
    }
}
