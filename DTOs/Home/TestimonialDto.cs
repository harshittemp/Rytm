namespace Rytm.DTOs.Home
{
    public class TestimonialDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public string Feedback { get; set; } = string.Empty;
    }
}
