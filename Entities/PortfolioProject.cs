namespace Rytm.Entities
{
    public class PortfolioProject
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public string? VimeoVideoId { get; set; }
        public string? ThumbnailUrl { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsPublished { get; set; }

        public int DisplayOrder { get; set; }
    }
}
