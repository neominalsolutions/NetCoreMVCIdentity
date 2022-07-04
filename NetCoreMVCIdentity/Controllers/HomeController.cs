using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVCIdentity.Models;
using System.Diagnostics;

namespace NetCoreMVCIdentity.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {

      HttpContext.User.IsInRole("Admin");


      return View();
    }


    // Kullanıcı login ise bu action tetiklenir
    [Authorize]
    public IActionResult Privacy()
    {
      return View();
    }


    [Authorize(Roles ="Admin")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}