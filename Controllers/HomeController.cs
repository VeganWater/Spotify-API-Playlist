using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SpotifyWebAPI.Models;
using SpotifyWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Controllers
{
	public class HomeController : Controller
	{

		public HomeController()
		{
			
		}

		
		public IActionResult Index()
		{
			LoginData loginData = new LoginData();
			return View(loginData);
		}

		//[HttpPost]
		//public ActionResult GetLoginData()
		//{
		//	return 
		//}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
