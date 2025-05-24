using NoticiasEnriquecidas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace NoticiasEnriquecidas.Services
{
    public class JsonPlaceholderService : IJsonPlaceholderService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/";

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public JsonPlaceholderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}posts");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Post>>(json, _jsonOptions);
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}posts/{postId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Post>(json, _jsonOptions);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}users/{userId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(json, _jsonOptions);
        }

        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}comments?postId={postId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Comment>>(json, _jsonOptions);
        }
    }
}
