namespace SSSAssessment.Models
{
    public class ApiResponse
    {
        public List<Client> Results { get; set; }
        public Metadata Metadata { get; set; }
    }

    public class Metadata
    {
        public int Page { get; set; }
        public int Count { get; set; }
        public int NumPages { get; set; }
    }
}
