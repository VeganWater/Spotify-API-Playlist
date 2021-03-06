using SpotifyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Services
{
	public interface ISpotifyService
	{
		Task<IEnumerable<Release>> GetNewReleases(string playlist_id, string accessTokken);
	}
}
