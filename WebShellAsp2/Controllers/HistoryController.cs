using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using WebShellAsp2.Models;

namespace WebShellAsp2.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HistoryController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // GET: HistoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistoryController/Details/5
        public async Task<ActionResult> DetailsView(int id)
        {
            var commandshistory = new List<CommandHistory>();
            var commands = new List<Command>();
            commandshistory = await Api.GetListAsync<List<CommandHistory>>("CommandHistory");
            commands = await Api.GetListAsync<List<Command>>("Command");
            if (id != null)
            {
                CommandHistory history = commandshistory.FirstOrDefault(s => s.ID == id);
                history.Command = commands.FirstOrDefault(s => s.ID == history.CommandId);
                if (history != null)
                    return View(history);
            }
            return NotFound();
        }
    }
}
