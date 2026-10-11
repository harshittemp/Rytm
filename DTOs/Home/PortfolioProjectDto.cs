namespace Rytm.DTOs.Home
{
    public class PortfolioProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? VimeoVideoId { get; set; }
        public string? ThumbnailUrl { get; set; }
    }
}
