using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using System.Diagnostics;
using WebShell2._0.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShell2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly WebShell_DBContext dbContext;
        public CommandController(WebShell_DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<CommandController>
        [HttpGet]
        public IEnumerable<CommandApi> Get()
        {
            return dbContext.Commands.Select(s=> (CommandApi)s);
        }


        // GET api/<CommandController>/5
        [HttpGet("CommandName")]
        public async Task<ActionResult<CommandApi>> Get(string commandName)
        {
            var command = dbContext.Commands.FirstOrDefault(s=> s.CommandName == commandName);
            if (command == null)
                return NotFound();
            //return Ok(CreateUnitApi(unit, products));
            return Ok((CommandApi)command);
        }

        // POST api/<CommandController>
        [HttpPost("CommandName")]
        public async Task<ActionResult<string>> PostCommand(string commandName)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.WorkingDirectory = @"C:\Windows\System32\"; //можно убрать @"C:\Windows\System32\" если ваш cmd хорошо работает. Данное свойство было добавлено для теста на моем ПК
            p.StartInfo.FileName = "cmd.exe";
            p.Start();
            p.StandardInput.WriteLine(commandName);
            p.StandardInput.WriteLine("exit");
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            Console.WriteLine(output);
            var comm = new CommandApi();
            comm.CommandEnter = output;
            var commands = dbContext.Commands.ToList();
            var search = commands.FirstOrDefault(s=> s.CommandName == commandName);
            if(search == null)
            {
                search = new Command();
                search.CommandName = commandName;
                dbContext.Commands.Add(search);
                dbContext.SaveChanges();
            }
            else
            {
                CommandHistory commandhistory = new CommandHistory();
                commandhistory.CommandAnswer = output;
                commandhistory.CommandId = search.Id;
                commandhistory.DateUsing = DateTime.Now;
                dbContext.CommandHistories.Add(commandhistory);
                dbContext.SaveChanges();
            }
            
            return Ok(output);
        }
    }
}
