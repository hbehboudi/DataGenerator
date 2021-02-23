using Nest;
using System;

namespace DataGenerator.Models
{
    internal class Card
    {
        [Text(Name = "id")]
        public Guid Id { get; set; }

        [Text(Name = "element_id")]
        public string ElementId { get; set; }

        [Text(Name = "branch_name")]
        public string BranchName { get; set; }

        [Text(Name = "branch_phone_number")]
        public string BranchPhoneNumber { get; set; }

        [Text(Name = "branch_address")]
        public string BranchAddress { get; set; }

        [Text(Name = "bank_name")]
        public string BankName { get; set; }

        [Text(Name = "branch_code")]
        public int BranchCode { get; set; }

        [Text(Name = "account_type")]
        public string AccountType { get; set; }

        [Text(Name = "card_number")]
        public string CardNumber { get; set; }

        [Text(Name = "account_number")]
        public string AccountNumber { get; set; }

        [Text(Name = "iban")]
        public string Iban { get; set; }

        public Card(
            Guid id,
            Branch bankBranch, 
            string accountType, 
            string accountNumber, 
            string cardNumber, 
            string iban)
        {
            Id = id;
            ElementId = "1";
            BranchName = bankBranch.Name;
            BranchPhoneNumber = bankBranch.PhoneNumber;
            BranchAddress = bankBranch.Address;
            BankName = bankBranch.BankName;
            BranchCode = bankBranch.Code;
            AccountType = accountType;
            CardNumber = cardNumber;
            AccountNumber = accountNumber;
            Iban = iban;
        }
    }
}
