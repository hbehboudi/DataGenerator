using System;
using System.Collections.Generic;
using DataGenerator.Extensions;
using DataGenerator.Models;

namespace DataGenerator.Generators
{
    public class CardGenerator
    {
        private static long id = -1;
        private readonly Random random = new Random();
        private readonly BranchGenerator bankGenerator = new BranchGenerator();

        public List<Card> GetCards(int count)
        {
            var cards = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                cards.Add(GetCard(bankGenerator.GetRandomBranch()));
            }

            return cards;
        }

        private Card GetCard(Branch bankBranch)
        {
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
                case "پارسیان":
                    return "622106";
                case "رسالت":
                    return "504172";
                case "سامان":
                    return "621986";
                case "سپه":
                    return "589210";
                case "سینا":
                    return "639346";
                case "شهر":
                    return "502806";
                case "صادرات":
                    return "603769";
                case "قوامین":
                    return "639599";
                case "کشاورزی":
                    return "603770";
                case "مسکن":
                    return "628023";
                case "ملت":
                    return "610433";
                case "ملی":
                    return "603799";
            }

            throw new NotImplementedException();
        }

        public string GetAccountType()
        {
            switch (random.Next(3))
            {
                case 0:
                    return "جاری";
                case 1:
                    return "سپرده";
                case 2:
                    return "پس انداز";
            }

            throw new NotImplementedException();
        }

        private string GetRandomStringNumber(int size)
        {
            int maxValue = 1;

            for (int i = 0; i < size; i++)
            {
                maxValue *= 10;
            }

            return random.Next(maxValue).Expand(size);
        }
    }
}
