namespace DataGenerator.Models
{
    internal class Branch
    {
        public int Code { get; set; }
        public string BankName { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; } 
        public string PhoneNumber { get; private set; }

        public Branch(
            string bankName,
            string name,
            string address, 
            string phoneNumber, 
            int code)
        {
            BankName = bankName;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Code = code;
        }
    }
}
