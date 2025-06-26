using Microsoft.AspNetCore.Mvc;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Usuario;

namespace Projeto_SCFII.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UsuarioLoginDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDTO model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var response = await _usuarioService.ValidarLoginAsync(model.Email, model.Senha);

            if (!response.Success || response.Data == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
                return View("Index", model);  // << aqui
            }
            return RedirectToAction("Index", "Usuario");
        }



        [HttpGet]
        public IActionResult Logout()
        {
            // TODO: Limpar sessão, cookies, etc.

            return RedirectToAction("Login");
        }
    }
}
