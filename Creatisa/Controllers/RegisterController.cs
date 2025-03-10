using Creatisa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Creatisa.Controllers;

public class RegisterController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger =  logger;

    public IActionResult Register()
    {
        Response.Headers.Append("HX-Trigger-After-Swap", """{"modalName":"register_modal"}""");
        return PartialView();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel registerViewModel)
    {
        Console.WriteLine(registerViewModel.Email);
        Console.WriteLine(registerViewModel.Password);
        return Created();
    }    
}