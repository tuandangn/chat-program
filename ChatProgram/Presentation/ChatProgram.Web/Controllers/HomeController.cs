using Microsoft.AspNetCore.Mvc;

namespace ChatProgram.Web.Controllers;

public sealed class HomeController : Controller
{
    public IActionResult Index() => View();
}
