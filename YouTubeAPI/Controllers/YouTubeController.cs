using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class YouTubeController : ControllerBase
{
    private readonly YouTubeApiService _youtubeService;

    public YouTubeController(YouTubeApiService youtubeService)
    {
        // Replace with your actual API Key
        _youtubeService = youtubeService;
    }

    [HttpGet("{type}/{id}")]
    public async Task<IActionResult> GetYouTubeDetails(string id, string type)
    {
        var result = await _youtubeService.GetYouTubeDetailsAsync(id, type);
        return Ok(result);
    }
}
