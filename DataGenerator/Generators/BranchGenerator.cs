using DataGenerator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace DataGenerator.Generators
{
    internal class BranchGenerator
    {
        private readonly List<Branch> branches;
        private readonly Random random = new Random();

        public BranchGenerator()
        {
            branches = new List<Branch>();
            var code = 1000;
            var path = ConfigurationManager.AppSettings["BranchesPath"];

            using (var reader = new StreamReader(path))
            {
                do
                {
                    var bankName = reader.ReadLine();
                    var branchName = reader.ReadLine();
                    var address = reader.ReadLine();
                    var phoneNumber = reader.ReadLine();
                    var branchCode = code++;
                    branches.Add(new Branch(bankName, branchName, address, phoneNumber, branchCode));
                }
                while (reader.ReadLine() != null);
            }
        }

        public Branch GetRandomBranch() => branches[random.Next(branches.Count)];
    }
}
