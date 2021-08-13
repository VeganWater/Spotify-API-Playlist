using SpotifyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Services
{
	public class SpotifyService : ISpotifyService
	{
		private readonly HttpClient _httpClient;

		//HTTP Client
		public SpotifyService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		//Ask for the Spotify playlist
		public async Task<IEnumerable<Release>> GetNewReleases(string playlist_id, string accessToken)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var response = await _httpClient.GetAsync($"playlists/{playlist_id}");

			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			var responseObject = await JsonSerializer.DeserializeAsync<GetNewReleases>(responseStream);

			return responseObject.tracks.items.Select(i => new Release
			{
				Name = i.track.name,
				Date = i.track.album.release_date,
				ImageUrl = i.track.album.images.FirstOrDefault().url,
				Link = i.track.album.external_urls.spotify,
				Artists = string.Join(",", i.track.artists.Select(i => i.name))
			});
		}
	}
}
