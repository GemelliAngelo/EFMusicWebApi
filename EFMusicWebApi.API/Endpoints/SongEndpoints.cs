using EFMusicWebApi.Infrastucture;
using EFMusicWebApi.Infrastucture.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using MusicWebApi.App.Models;

namespace EFMusicWebApi.API.Endpoints
{
    public static class SongEndpoints
    {
        public static void MapSongEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("api/songs");

            endpoints.MapGet("/", Get);
            endpoints.MapGet("/search", Search);
        }

        static List<Song> Get(MusicService musicService)
        {
            return musicService.GetSongs();
        }

        static Results<Ok<Song>, NotFound, ProblemHttpResult> Search(MusicService musicService, string title)
        {

            var result = musicService.GetSongs(title).First();
            return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
        }
    }
}
