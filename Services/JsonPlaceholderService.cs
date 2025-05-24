using NoticiasEnriquecidas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace NoticiasEnriquecidas.Services
{
    //aqui se define la interfaz IJsonPlaceholderService
    public class JsonPlaceholderService : IJsonPlaceholderService
    {
        //aqui se define la variable _httpClient
        private readonly HttpClient _httpClient;
        //aqui se define la variable BaseUrl
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/";
        //aqui se define la variable _jsonOptions
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        //aqui se define la variable _jsonOptions
        {
            PropertyNameCaseInsensitive = true
        };
        //aqui se define el constructor JsonPlaceholderService
        public JsonPlaceholderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //aqui se define el metodo GetPostsAsync
        public async Task<List<Post>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}posts");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Post>>(json, _jsonOptions);
        }
        //aqui se define el metodo GetPostByIdAsync
        public async Task<Post> GetPostByIdAsync(int postId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}posts/{postId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Post>(json, _jsonOptions);
        }
        //aqui se define el metodo GetUserByIdAsync
        public async Task<User> GetUserByIdAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}users/{userId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(json, _jsonOptions);
        }
        //aqui se define el metodo GetCommentsByPostIdAsync

        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}comments?postId={postId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Comment>>(json, _jsonOptions);
        }
    }
}
