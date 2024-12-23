using Microsoft.AspNetCore.Mvc;

namespace MicroSassApi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
