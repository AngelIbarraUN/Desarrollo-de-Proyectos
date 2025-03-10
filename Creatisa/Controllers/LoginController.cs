using Creatisa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Creatisa.Controllers;

public class LoginController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger =  logger;

    public IActionResult Login()
    {
        Response.Headers.Append("HX-Trigger-After-Swap", """{"modalName":"login_modal"}""");
        return PartialView();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel loginViewModel)
    {
        Console.WriteLine(loginViewModel.Email);
        Console.WriteLine(loginViewModel.Password);
        return Created();
    }
}