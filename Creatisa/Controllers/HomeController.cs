using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Creatisa.Models;

namespace Creatisa.Controllers;
public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    
    public IActionResult Index() => View();
    
    public IActionResult Main() =>  PartialView("Main");
    
    public IActionResult About() => PartialView("About");
    
    public IActionResult Methodology() => PartialView("Methodology");

    public IActionResult FrequentlyAsked() => PartialView("FrequentlyAsked");

    public IActionResult Search() => PartialView("Search");
    
    public IActionResult Privacy() => PartialView("Privacy");
 
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}