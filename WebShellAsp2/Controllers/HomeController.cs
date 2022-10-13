using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShellAsp2.Models;

namespace WebShellAsp2.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult History()
        {
            return View(/*здесь нужен вывод из сервера*/);
        }

        public IActionResult EnterCommand(Command command)
        {
            Command c = new Command();
            c.CommandName = command.CommandName;
            return RedirectToAction("Privacy"); //заглушка
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}