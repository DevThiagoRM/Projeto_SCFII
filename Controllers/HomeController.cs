using Microsoft.AspNetCore.Mvc;

namespace Projeto_SCFII.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
