namespace SSSAssessment.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nino { get; set; }
        public Address Address { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        public string Avatar { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }

    public class PaymentDetails
    {
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
    }

}
