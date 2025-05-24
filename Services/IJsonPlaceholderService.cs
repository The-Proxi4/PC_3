using NoticiasEnriquecidas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoticiasEnriquecidas.Services
{
    public interface IJsonPlaceholderService
    {
        Task<List<Post>> GetPostsAsync();
        Task<Post> GetPostByIdAsync(int postId);
        Task<User> GetUserByIdAsync(int userId);
        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}
