using DataGenerator.Extensions;
using DataGenerator.Models;
using System;
using System.Collections.Generic;

namespace DataGenerator.Generators
{
    public class TransactionGenerator
    {
        private static long id = 999_999_999;
        private readonly Random random = new Random();
        private readonly int cardCount;

        public TransactionGenerator(int cardCount)
        {
            this.cardCount = cardCount;
        }

        public List<Transaction> GetTransactions(int count)
        {
            var transactions = new List<Transaction>();

            for (int i = 0; i < count; i++)
            {
                transactions.Add(GetTransaction());
            }

            return transactions;
        }

        private Transaction GetTransaction()
        {
            id++;

            var sourceId = random.Next(cardCount).ToGuid();
            var targetId = random.Next(cardCount).ToGuid();

            while (sourceId == targetId)
            {
                targetId = random.Next(cardCount).ToGuid();
            }

            return new Transaction(id.ToGuid(), sourceId, targetId, GetRandomDate(), GetRandomTime(),
                GetRandomState(), GetRandomIssueTracking(), GetRandomAmount());
        }

        private string GetRandomDate()
        {
            var year = random.Next(1390, 1399).Expand(4);
            var month = random.Next(1, 13).Expand(2);
            var day = random.Next(1, 30).Expand(2);

            return year + "/" + month + "/" + day;
        }

        private string GetRandomTime()
        {
            var hour = random.Next(0, 24).Expand(2);
            var minute = random.Next(0, 60).Expand(2);
            var second = random.Next(0, 60).Expand(2);

            return hour + ":" + minute + ":" + second;
        }

        private string GetRandomState()
        {
            if (random.Next(5) == 0)
            {
                return "ناموفق";
            }

            return "موفق";
        }

        private int GetRandomIssueTracking()
        {
            return random.Next(100_000, 1_000_000);
        }

        private int GetRandomAmount()
        {
            switch (random.Next(10))
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return random.Next(10_000, 100_000);
                case 4:
                case 5:
                case 6:
                    return random.Next(100_000, 1_000_000);
                case 7:
                case 8:
                    return random.Next(1_000_000, 10_000_000);
                case 9:
                    return random.Next(10_000_000, 100_000_000);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
