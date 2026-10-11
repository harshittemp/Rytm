namespace Rytm.Entities
{
    public class ServiceEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
