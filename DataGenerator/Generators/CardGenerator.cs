using System;
using System.Collections.Generic;
using DataGenerator.ConstValues;
using DataGenerator.Extensions;
using DataGenerator.Models;

namespace DataGenerator.Generators
{
    internal class CardGenerator
    {
        private static long id = -1;
        private readonly Random random = new Random();
        private readonly BranchGenerator bankGenerator = new BranchGenerator();

        public List<Card> GetCards(int count)
        {
            var cards = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                cards.Add(GetCard());
            }

            return cards;
        }

        private Card GetCard()
        {
            var bankBranch = bankGenerator.GetRandomBranch();

            var id = GetId();
            var accountType = GetAccountType();
            var accountNumber = GetAccountNumber(id);
            var cardNumber = GetCardNumber(id, bankBranch.BankName);
            var iban = GetIban(accountNumber);

            return new Card(id.ToGuid(), bankBranch, accountType, accountNumber, cardNumber, iban);
        }

        private long GetId()
        {
            id++;

            if (id < 1_000_000_000)
            {
                return id;
            }

            throw new NotImplementedException();
        }

        private string GetAccountNumber(long id) =>
            GetRandomStringNumber(4) + id.Expand(9);

        private string GetCardNumber(long id, string bankName) =>
            GetCardCode(bankName) + GetRandomStringNumber(1) + id.Expand(9);

        private string GetIban(string accountNumber) =>
            "IR" + GetRandomStringNumber(6) + GetRandomStringNumber(5) + accountNumber;

        private string GetCardCode(string bankName)
        {
            switch (bankName)
            {
                case BankNameConstValues.Parsian:
                    return CardCodeConstValues.Parsian;
                case BankNameConstValues.Resalat:
                    return CardCodeConstValues.Resalat;
                case BankNameConstValues.Saman:
                    return CardCodeConstValues.Saman;
                case BankNameConstValues.Sepah:
                    return CardCodeConstValues.Sepah;
                case BankNameConstValues.Sina:
                    return CardCodeConstValues.Sina;
                case BankNameConstValues.Shahr:
                    return CardCodeConstValues.Shahr;
                case BankNameConstValues.Saderat:
                    return CardCodeConstValues.Saderat;
                case BankNameConstValues.Ghavamin:
                    return CardCodeConstValues.Ghavamin;
                case BankNameConstValues.Keshavarzi:
                    return CardCodeConstValues.Keshavarzi;
                case BankNameConstValues.Maskan:
                    return CardCodeConstValues.Maskan;
                case BankNameConstValues.Mellat:
                    return CardCodeConstValues.Mellat;
                case BankNameConstValues.Melli:
                    return CardCodeConstValues.Melli;
                default: throw new NotImplementedException();
            }
        }

        public string GetAccountType()
        {
            switch (random.Next(3))
            {
                case 0:
                    return AccountTypeConstValues.CurrentAccount;
                case 1:
                    return AccountTypeConstValues.DepositAccount;
                case 2:
                    return AccountTypeConstValues.SavingAccount;
                default:
                    throw new NotImplementedException();
            }
        }

        private string GetRandomStringNumber(int size)
        {
            var maxValue = (int)Math.Pow(10, size);
            return random.Next(maxValue).Expand(size);
        }
    }
}
