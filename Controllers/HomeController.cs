
using Microsoft.AspNetCore.Mvc;
using Rytm.Services;

namespace Rytm.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly IHomeService _homeService;

    public HomeController(IHomeService homeService)
    {
        _homeService = homeService;
    }

    /// <summary>
    /// Get the home page content.
    /// URL : http://localhost:5242/api/Home
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetHomePage(CancellationToken cancellationToken)
    {
        var homePage = await _homeService.GetHomePageAsync(
            cancellationToken);

        if (homePage is null)
        {
            return NotFound();
        }

        return Ok(homePage);
    }
}
