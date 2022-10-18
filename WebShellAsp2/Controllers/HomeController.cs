using Microsoft.AspNetCore.Mvc;
using ModelsApi;
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

        public async Task<IActionResult> History()
        {
            var commands = new List<CommandHistory>();
            commands = await Api.GetListAsync<List<CommandHistory>>("CommandHistory");
            var commandsapi = new List<Command>();
            commandsapi = await Api.GetListAsync<List<Command>>("Command");
            foreach(var command in commands)
            {
                command.Command = commandsapi.FirstOrDefault(s => s.ID == command.CommandId);
            }
            return View("History", commands);
        }

        public async Task<IActionResult> EnterCommand(string CommandName)
        {
            Command c = new Command();
            c.CommandName = CommandName;
            CommandApi commandApi = new CommandApi();
            commandApi.CommandName = CommandName;
            var commandApi1 = await Api.PostAsync(commandApi, "Command", CommandName);
            var commandhistory = new List<CommandHistory>();
            commandhistory = await Api.GetListAsync<List<CommandHistory>>("CommandHistory");
            foreach(var history in commandhistory)
            {
                c.CommandEnter = history.CommandAnswer;
            }
            return View("Index", c);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}