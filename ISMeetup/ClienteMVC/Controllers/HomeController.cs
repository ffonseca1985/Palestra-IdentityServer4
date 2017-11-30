using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClienteMVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using IdentityServer4;

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
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
