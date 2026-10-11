
using EditAgency.Api.Data;
using Microsoft.EntityFrameworkCore;
using Rytm.DTOs.Home;

namespace Rytm.Services
{
    public class HomeService(AppDbContext dbContext) : IHomeService
    {
        public async Task<HomePageDto?> GetHomePageAsync(
            CancellationToken cancellationToken)
        {
            var homePage = await dbContext.HomePageContents
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (homePage is null)
            {
                return null;
            }

            var services = await dbContext.Services
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new ServiceDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Slug = x.Slug,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync(cancellationToken);

            var featuredProjects = await dbContext.PortfolioProjects
                .AsNoTracking()
                .Where(x => x.IsPublished && x.IsFeatured)
                .OrderBy(x => x.DisplayOrder)
                .Take(6)
                .Select(x => new PortfolioProjectDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Category = x.Category,
                    VimeoVideoId = x.VimeoVideoId,
                    ThumbnailUrl = x.ThumbnailUrl
                })
                .ToListAsync(cancellationToken);

            var testimonials = await dbContext.Testimonials
                .AsNoTracking()
                .Where(x => x.IsPublished)
                .OrderBy(x => x.DisplayOrder)
                .Take(3)
                .Select(x => new TestimonialDto
                {
                    Id = x.Id,
                    ClientName = x.ClientName,
                    CompanyName = x.CompanyName,
                    Feedback = x.Feedback
                })
                .ToListAsync(cancellationToken);

            return new HomePageDto
            {
                Eyebrow = homePage.Eyebrow,
                Headline = homePage.Headline,
                Description = homePage.Description,
                PrimaryCtaText = homePage.PrimaryCtaText,
                PrimaryCtaUrl = homePage.PrimaryCtaUrl,
                SecondaryCtaText = homePage.SecondaryCtaText,
                SecondaryCtaUrl = homePage.SecondaryCtaUrl,
                Services = services,
                FeaturedProjects = featuredProjects,
                Testimonials = testimonials
            };
        }
    }
}
