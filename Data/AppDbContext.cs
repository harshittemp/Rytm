using Microsoft.EntityFrameworkCore;
using Rytm.Entities;

namespace EditAgency.Api.Data;

public  class AppDbContext(DbContextOptions<AppDbContext> options)  : DbContext(options)
{
    public DbSet<HomePageContent> HomePageContents =>
        Set<HomePageContent>();

    public DbSet<ServiceEntity> Services =>
        Set<ServiceEntity>();

    public DbSet<PortfolioProject> PortfolioProjects =>
        Set<PortfolioProject>();

    public DbSet<Testimonial> Testimonials =>
        Set<Testimonial>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<HomePageContent>(entity =>
        {
            entity.ToTable("HomePageContents");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Headline)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired();
        });

        modelBuilder.Entity<ServiceEntity>(entity =>
        {
            entity.ToTable("Services");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Slug)
                .HasMaxLength(120)
                .IsRequired();

            entity.HasIndex(x => x.Slug)
                .IsUnique();
        });

        modelBuilder.Entity<PortfolioProject>(entity =>
        {
            entity.ToTable("PortfolioProjects");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Category)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.VimeoVideoId)
                .HasMaxLength(50);

            entity.HasIndex(x => new
            {
                x.IsPublished,
                x.IsFeatured,
                x.DisplayOrder
            });
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.ToTable("Testimonials");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.ClientName)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(x => x.Feedback)
                .HasMaxLength(2000)
                .IsRequired();
        });

        // Initial home page content.
        modelBuilder.Entity<HomePageContent>().HasData(
            new HomePageContent
            {
                Id = 1,
                Eyebrow = "VIDEO EDITING STUDIO",
                Headline = "Your Vision. Our Edit.",
                Description =
                    "Professional video editing for creators and brands.",
                PrimaryCtaText = "Start Your Project",
                PrimaryCtaUrl = "/contact",
                SecondaryCtaText = "View Our Work",
                SecondaryCtaUrl = "/portfolio"
            });

        modelBuilder.Entity<ServiceEntity>().HasData(
            new ServiceEntity
            {
                Id = 1,
                Name = "YouTube Video Editing",
                Description =
                    "Engaging long-form videos designed for your audience.",
                Slug = "youtube-video-editing",
                DisplayOrder = 1,
                IsActive = true
            },
            new ServiceEntity
            {
                Id = 2,
                Name = "Short-Form Videos",
                Description =
                    "Reels and Shorts edited for social platforms.",
                Slug = "short-form-videos",
                DisplayOrder = 2,
                IsActive = true
            },
            new ServiceEntity
            {
                Id = 3,
                Name = "Podcast Editing",
                Description =
                    "Polished podcast videos with clean cuts and captions.",
                Slug = "podcast-editing",
                DisplayOrder = 3,
                IsActive = true
            });
    }
}