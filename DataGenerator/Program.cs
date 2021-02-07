using DataGenerator.Generators;
using System.IO;

namespace DataGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cards = new CardGenerator().GetCards(1000);

            using (var file = new StreamWriter(@"C:\Users\Hossein\Desktop\A.csv"))
            {
                foreach (var card in cards)
                {
                    file.WriteLine(card.ToString());
                }
            }

            var transactions = new TransactionGenerator(1000).GetTransactions(20_000);

            using (var file2 = new StreamWriter(@"C:\Users\Hossein\Desktop\B.csv"))
            {
                foreach (var transaction in transactions)
                {
                    file2.WriteLine(transaction.ToString());
                }
            }

        }
    }
}
