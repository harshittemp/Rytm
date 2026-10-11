using Rytm.DTOs.Home;

namespace Rytm.Services
{
    public interface IHomeService
    {
        Task<HomePageDto?> GetHomePageAsync( CancellationToken cancellationToken);
    }
}
