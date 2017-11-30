using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClienteMVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using IdentityModel.Client;
using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace ClienteMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Logout()
        {
            //Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> InfoUser()
        {
            //IdentityModel => Classe muita legal para se trabalhar com OAuth
            var disco = await DiscoveryClient.GetAsync("http://localhost:1728/");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }

            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            ViewBag.content = "";

            var response = await client.GetAsync("http://localhost:3038/api/Values");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                ViewBag.content = content;
                Console.WriteLine(JArray.Parse(content));
            }

            return View();
        }
    }
}
