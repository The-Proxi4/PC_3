using Microsoft.AspNetCore.Mvc;

namespace NoticiasEnriquecidas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
