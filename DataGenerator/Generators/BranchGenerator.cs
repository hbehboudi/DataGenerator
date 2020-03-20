using DataGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataGenerator.Generators
{
    public class BranchGenerator
    {
        public List<Branch> Branches { get; private set; }
        private readonly Random random = new Random();

        public BranchGenerator()
        {
            Branches = new List<Branch>();
            int code = 1000;

            using (var reader = new StreamReader("../../../data/branches.txt"))
            {
                do
                {
                    var bankName = reader.ReadLine();
                    var branchName = reader.ReadLine();
                    var address = reader.ReadLine();
                    var phoneNumber = reader.ReadLine();
                    var branchCode = code;
                    code++;
                    Branches.Add(new Branch(bankName, branchName, address, phoneNumber, branchCode));
                } while (reader.ReadLine() != null);
            }
        }

        public Branch GetRandomBranch()
        {
            return Branches[random.Next(Branches.Count)];
        }
    }
}
