using EFMusicWebApi.Infrastucture.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using MusicWebApi.App.Models;

namespace EFMusicWebApi.API.Endpoints
{
    public static class ArtistEndpoints
    {
        public static void MapArtistEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("api/artists");

            endpoints.MapGet("/", Get);
            endpoints.MapGet("/search", Search);
            endpoints.MapPost("/add", Add);
            endpoints.MapPut("/update", Update);
            endpoints.MapDelete("/delete", Delete);
        }

        static List<Artist> Get(MusicService musicService)
        {
            return musicService.GetArtists();
        }

        static Results<Ok<Artist>, NotFound, ProblemHttpResult> Search(MusicService musicService, string name)
        {
            var result = musicService.GetArtists(name)?.First();

            return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
        }

        static void Add(MusicService musicService, Artist artist)
        {
            musicService.AddArtist(artist);
        }

        static void Update(MusicService musicService, int id, Artist artist)
        {
            musicService.UpdateArtist(id, artist);
        }

        static void Delete(MusicService musicService, int id)
        {
            musicService.DeleteArtist(id);
        }
    }
}
