namespace Rytm.Entities
{
    public class Testimonial
    {
        public int Id { get; set; }

        public string ClientName { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public string Feedback { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }
        public bool IsPublished { get; set; }
    }
}
