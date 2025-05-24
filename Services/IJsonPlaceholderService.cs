using NoticiasEnriquecidas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoticiasEnriquecidas.Services
{
    public interface IJsonPlaceholderService
    {
        //aqui estamos definiendo los metodos que se van a usar en el controlador
        Task<List<Post>> GetPostsAsync();
        //en este caso no es necesario el async ya que no se va a usar el await
        Task<Post> GetPostByIdAsync(int postId);
        //el post es el que se va a usar para obtener el id del usuario
        Task<User> GetUserByIdAsync(int userId);
        //el get comments es el que se va a usar para obtener los comentarios
        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}
