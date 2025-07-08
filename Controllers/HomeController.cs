using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MVCPizzaria.Controllers
{
    public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}
