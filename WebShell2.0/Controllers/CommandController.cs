using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShell2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        // GET: api/<CommandController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET api/<CommandController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommandController>
        [HttpPost("Name")]
        public void MkDir([FromBody] string path, string name)
        {
            Directory.CreateDirectory($@"C:\Users\User\{name}");
        }
        [HttpPost]
        public async Task<ActionResult<string>> Mkdir([FromBody] string path, string name)
        {
            string dirName = $@"C:\Users\User\{name}";
            // если папка существует
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }

            }
            else
            {
                return BadRequest("Command = null");
            }
            return Ok($"{name}");
        }

        // PUT api/<CommandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
