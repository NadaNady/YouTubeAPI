using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System.Threading.Tasks;

public class YouTubeApiService
{
    private readonly string _apiKey;

    public YouTubeApiService(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task<object> GetYouTubeDetailsAsync(string id, string type)
    {
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = _apiKey,
            ApplicationName = "YouTubeAPI"
        });

        switch (type.ToLower())
        {
            case "video":
                var videoRequest = youtubeService.Videos.List("snippet,contentDetails,statistics");
                videoRequest.Id = id;
                var videoResponse = await videoRequest.ExecuteAsync();
                return videoResponse.Items;

            case "playlist":
                var playlistRequest = youtubeService.Playlists.List("snippet,contentDetails");
                playlistRequest.Id = id;
                var playlistResponse = await playlistRequest.ExecuteAsync();
                return playlistResponse.Items;

            default:
                return "Invalid Type (Use 'video' or 'playlist')";
        }
    }
}
