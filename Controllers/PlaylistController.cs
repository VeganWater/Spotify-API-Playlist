using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpotifyWebAPI.Models;
using SpotifyWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Controllers
{
	public class PlaylistController : Controller
	{

		private readonly ISpotifyAccountService _spotifyAccountService;
		private readonly IConfiguration _configuration;
		private readonly ISpotifyService _spotifyService;

		public PlaylistController(
			ISpotifyAccountService spotifyAccountService,
			IConfiguration configuration,
			ISpotifyService spotifyService)
		{
			_spotifyAccountService = spotifyAccountService;
			_configuration = configuration;
			_spotifyService = spotifyService;
		}

		public async Task<IActionResult> Index()
		{
			var newReleases = await GetReleases();

			return View(newReleases);
		}

		private async Task<IEnumerable<Release>> GetReleases()
		{
			try
			{
				var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

				var newReleases = await _spotifyService.GetNewReleases("5ebOveCY6Bzi375D8MWFO2", token);

				return newReleases;
			}
			catch (Exception ex)
			{
				Debug.Write(ex);

				return Enumerable.Empty<Release>();
			}
		}
	}
}
