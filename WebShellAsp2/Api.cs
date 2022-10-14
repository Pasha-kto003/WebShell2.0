using ModelsApi;
using System.Text;
using System.Text.Json;
using WebShellAsp2.Models;

namespace WebShellAsp2
{
    public class Api
    {
        static HttpClient client = new HttpClient(); //
        static string server = "http://localhost:5179/api/";
        static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task<T> GetListAsync<T>(string controller)
        {
            var answer = await client.GetAsync(server + controller);
            string answerText = await answer.Content.ReadAsStringAsync();
            var result = (T)JsonSerializer.Deserialize(answerText, typeof(T), jsonOptions);
            return result;
        }

        public static async Task<T> PostAsync<T>(T value, string controller, string commandName) /*where T : ModelApi.ApiBaseType*/ //http://localhost:5179/api/Command/CommandName
        {
            CommandApi command = new CommandApi();
            command = value as CommandApi;
            var str = JsonSerializer.Serialize(value, typeof(T));
            var answer = await client.PostAsync(server + controller + $"/{commandName}",  new StringContent(str, Encoding.UTF8, "application/json"));
            if (answer.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return value;
            string answerText = await answer.Content.ReadAsStringAsync();
            //if (!int.TryParse(answerText, out int result))
            //    return null;
            return value;
        }

        public static async Task<T> EnterAsync<T>(T value, string password, string controller) /*where T : ModelApi.ApiBaseType*/
        {
            var str = JsonSerializer.Serialize(value, typeof(T));
            var answer = await client.PostAsync(server + controller, new StringContent(str, Encoding.UTF8, "application/json"));
            string answerText = await answer.Content.ReadAsStringAsync();
            var result = (T)JsonSerializer.Deserialize(answerText, typeof(T), jsonOptions);
            return result;
        }

    }
}
