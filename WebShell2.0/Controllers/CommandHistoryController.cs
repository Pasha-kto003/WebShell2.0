using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using WebShell2._0.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShell2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandHistoryController : ControllerBase
    {
        private readonly WebShell_DBContext dbContext;
        public CommandHistoryController(WebShell_DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<CommandHistoryController>
        [HttpGet]
        public IEnumerable<CommandHistoryApi> Get()
        {
            return dbContext.CommandHistories.Select(s => (CommandHistoryApi)s);
        }

        [HttpGet("CommandAnswer")]
        public async Task<ActionResult> GetByAnswer(string commandAnswer)
        {
            commandAnswer = commandAnswer.ToString();
            var commands = dbContext.CommandHistories.Select(s=> s.CommandAnswer == commandAnswer);
            if(commands == null)
            {
                BadRequest("NotFound commands in history");
            }
            return Ok(commands);
        }
    }
}
