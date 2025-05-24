using NoticiasEnriquecidas.Services;
using NoticiasEnriquecidas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace NoticiasEnriquecidas.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly IJsonPlaceholderService _jsonService;

        public NoticiasController(IJsonPlaceholderService jsonService)
        {
            _jsonService = jsonService;
        }

        // GET: /Noticias
        public async Task<IActionResult> Index()
        {
            List<Post> posts = await _jsonService.GetPostsAsync();
            return View(posts);
        }

        // GET: /Noticias/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Post post = await _jsonService.GetPostByIdAsync(id);
            User author = await _jsonService.GetUserByIdAsync(post.UserId);
            List<Comment> comments = await _jsonService.GetCommentsByPostIdAsync(id);

            var viewModel = new PostDetailsViewModel
            {
                Post = post,
                Author = author,
                Comments = comments
            };

            return View(viewModel);
        }
    }
}