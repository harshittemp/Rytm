namespace Rytm.Entities
{
    public class HomePageContent
    {
        public int Id { get; set; }

        public string Eyebrow { get; set; } = string.Empty;
        public string Headline { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string PrimaryCtaText { get; set; } = string.Empty;
        public string PrimaryCtaUrl { get; set; } = string.Empty;

        public string SecondaryCtaText { get; set; } = string.Empty;
        public string SecondaryCtaUrl { get; set; } = string.Empty;
    }
}
