using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class ChatBotService
{
    private readonly string _endpoint = "YOUR_OPENAI_ENDPOINT"; // Replace with your OpenAI endpoint
    private readonly string _apiKey = "YOUR_OPENAI_API_KEY"; // Replace with your OpenAI API key
    private HttpClient _httpClient;

    public ChatBotService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
    }

    public async Task<string> SendMessageAsync(string message)
    {
        var requestBody = new
        {
            model = "text-davinci-003", // Replace with your model
            prompt = message,
            max_tokens = 150
        };

        var jsonRequestBody = JObject.FromObject(requestBody).ToString();
        var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(_endpoint, content);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var jsonResponse = JObject.Parse(responseBody);

        var botMessage = jsonResponse["choices"]?.First?["text"]?.ToString();
        return botMessage?.Trim();
    }
}

