namespace Rytm.DTOs.Home
{
    public class HomePageDto
    {
        public string Eyebrow { get; set; } = string.Empty;
        public string Headline { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PrimaryCtaText { get; set; } = string.Empty;
        public string PrimaryCtaUrl { get; set; } = string.Empty;
        public string SecondaryCtaText { get; set; } = string.Empty;
        public string SecondaryCtaUrl { get; set; } = string.Empty;
        public List<ServiceDto> Services { get; set; } = new List<ServiceDto>();
        public List<PortfolioProjectDto> FeaturedProjects { get; set; } = new List<PortfolioProjectDto>();
        public List<TestimonialDto> Testimonials { get; set; } = new List<TestimonialDto>();
    }
}
