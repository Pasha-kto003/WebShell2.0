using System.Text.Json;

namespace WebShellAsp
{
    public class Api
    {
        static HttpClient client = new HttpClient();
        static string server = "http://localhost:39668";
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
    }
}
