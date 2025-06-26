using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Usuario;
using Projeto_SCFII.Infrastructure.Application.Filters;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ICargoService _cargoService;
        private readonly IDepartamentoService _departamentoService;
        private readonly IGeneroService _generoService;
        private readonly IRacaService _racaService;
        private readonly IStatusUsuarioService _statusUsuarioService;
        private readonly ITipoUsuarioService _tipoUsuarioService;

        public UsuarioController(
            IUsuarioService usuarioService,
            ICargoService cargoService,
            IDepartamentoService departamentoService,
            IGeneroService generoService,
            IRacaService racaService,
            IStatusUsuarioService statusUsuarioService,
            ITipoUsuarioService tipoUsuarioService)
        {
            _usuarioService = usuarioService;
            _cargoService = cargoService;
            _departamentoService = departamentoService;
            _generoService = generoService;
            _racaService = racaService;
            _statusUsuarioService = statusUsuarioService;
            _tipoUsuarioService = tipoUsuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _usuarioService.GetAllUsuariosAsync();
            if (!response.Success)
            {
                return View(new List<UsuarioDTO>());
            }

            return View(response.Data);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _usuarioService.GetAllUsuariosAsync();
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _usuarioService.GetUsuarioByIdAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var response = await _usuarioService.GetUsuarioByEmailAsync(email);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopularDropdownDeCargos();
            await PopularDropdownDeDepartamentos();
            await PopularDropdownDeGeneros();
            await PopularDropdownDeRacas();
            await PopularDropdownDeStatusUsuario();
            await PopularDropdownDeTipoUsuario();
            return View();
        }

        [HttpGet("editar/{id}")]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _usuarioService.GetUsuarioByIdAsync(id);

            if (!response.Success || response.Data == null)
                return NotFound();

            var usuario = response.Data;

            var dto = new UsuarioUpdateDTO
            {
                Nome = usuario.Nome!,
                Sobrenome = usuario.Sobrenome!,
                Email = usuario.Email!,
                CargoId = usuario.CargoId,
                DepartamentoId = usuario.DepartamentoId,
                RacaId = usuario.RacaId,
                GeneroId = usuario.GeneroId,
                TipoUsuarioId = usuario.TipoUsuarioId,
                StatusUsuarioId = usuario.StatusUsuarioId,
            };

            ViewBag.Cargos = new SelectList((await _cargoService.GetAllAsync()).Data, "Id", "NomeCargo");
            ViewBag.Departamentos = new SelectList((await _departamentoService.GetAllAsync()).Data, "Id", "NomeDepartamento");
            ViewBag.Racas = new SelectList((await _racaService.GetAllAsync()).Data, "Id", "NomeRaca");
            ViewBag.Generos = new SelectList((await _generoService.GetAllAsync()).Data, "Id", "NomeGenero");
            ViewBag.TiposUsuario = new SelectList((await _tipoUsuarioService.GetAllAsync()).Data, "Id", "TipoDeUsuario");
            ViewBag.StatusUsuarios = new SelectList((await _statusUsuarioService.GetAllAsync()).Data, "Id", "Status");

            return View("Update", dto);
        }

        [HttpGet("detalhes/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _usuarioService.GetUsuarioByIdAsync(id);

            if (!response.Success || response.Data == null)
                return NotFound();

            var usuario = response.Data;

            var dto = new UsuarioUpdateDTO
            {
                Nome = usuario.Nome!,
                Sobrenome = usuario.Sobrenome!,
                Email = usuario.Email!,
                CargoId = usuario.CargoId,
                DepartamentoId = usuario.DepartamentoId,
                RacaId = usuario.RacaId,
                GeneroId = usuario.GeneroId,
                TipoUsuarioId = usuario.TipoUsuarioId,
                StatusUsuarioId = usuario.StatusUsuarioId,
            };

            ViewBag.Cargos = new SelectList((await _cargoService.GetAllAsync()).Data, "Id", "NomeCargo", usuario.CargoId);
            ViewBag.Departamentos = new SelectList((await _departamentoService.GetAllAsync()).Data, "Id", "NomeDepartamento", usuario.DepartamentoId);
            ViewBag.Racas = new SelectList((await _racaService.GetAllAsync()).Data, "Id", "NomeRaca", usuario.RacaId);
            ViewBag.Generos = new SelectList((await _generoService.GetAllAsync()).Data, "Id", "NomeGenero", usuario.GeneroId);
            ViewBag.TiposUsuario = new SelectList((await _tipoUsuarioService.GetAllAsync()).Data, "Id", "TipoDeUsuario", usuario.TipoUsuarioId);
            ViewBag.StatusUsuarios = new SelectList((await _statusUsuarioService.GetAllAsync()).Data, "Id", "Status", usuario.StatusUsuarioId);

            return View("Details", dto);
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var response = await _usuarioService.GetDataDashboardAsync();
            if (!response.Success)
            {
                return View(new DashboardDTO());
            }

            return View(response.Data);
        }


        private async Task PopularDropdownDeCargos()
        {
            var response = await _cargoService.GetAllAsync();
            if (response.Success)
            {
                ViewBag.Cargos = new SelectList(response.Data, "Id", "NomeCargo");
            }
            else
            {
                ViewBag.Cargos = new SelectList(Enumerable.Empty<Cargo>(), "Id", "NomeCargo");
            }
        }

        private async Task PopularDropdownDeDepartamentos()
        {
            var response = await _departamentoService.GetAllAsync();
            if (response.Success)
            {
                ViewBag.Departamentos = new SelectList(response.Data, "Id", "NomeDepartamento");
            }
            else
            {
                ViewBag.Departamentos = new SelectList(Enumerable.Empty<Cargo>(), "Id", "NomeDepartamento");
            }
        }

        private async Task PopularDropdownDeGeneros()
        {
            var response = await _generoService.GetAllAsync();
            if (response.Success)
            {
                ViewBag.Generos = new SelectList(response.Data, "Id", "NomeGenero");
            }
            else
            {
                ViewBag.Generos = new SelectList(Enumerable.Empty<Cargo>(), "Id", "NomeGenero");
            }
        }

        private async Task PopularDropdownDeRacas()
        {
            var response = await _racaService.GetAllAsync();
            if (response.Success)
            {
                ViewBag.Racas = new SelectList(response.Data, "Id", "NomeRaca");
            }
            else
            {
                ViewBag.Racas = new SelectList(Enumerable.Empty<Cargo>(), "Id", "NomeRaca");
            }
        }

        private async Task PopularDropdownDeStatusUsuario()
        {
            var response = await _statusUsuarioService.GetAllAsync();
            if (response.Success)
            {
                ViewBag.StatusUsuarios = new SelectList(response.Data, "Id", "Status");
            }
            else
            {
                ViewBag.StatusUsuarios = new SelectList(Enumerable.Empty<Cargo>(), "Id", "Status");
            }
        }

        private async Task PopularDropdownDeTipoUsuario()
        {
            var response = await _tipoUsuarioService.GetAllAsync();
            if (response.Success)
            {
                ViewBag.TiposUsuario = new SelectList(response.Data, "Id", "TipoDeUsuario");
            }
            else
            {
                ViewBag.TiposUsuario = new SelectList(Enumerable.Empty<Cargo>(), "Id", "TipoDeUsuario");
            }
        }

        [HttpPost("filtro")]
        public async Task<IActionResult> GetByFiltro([FromBody] UsuarioFiltro filtro)
        {
            var response = await _usuarioService.GetUsuariosByFiltroAsync(filtro);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioCreateDTO usuarioCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _usuarioService.CreateUsuarioAsync(usuarioCreateDto);
            if (!response.Success || response.Data == null)
                return BadRequest(response.Message);

            //CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);

            return RedirectToAction("Index", "Usuario");
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateDTO usuarioUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _usuarioService.UpdateUsuarioAsync(id, usuarioUpdateDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _usuarioService.DeleteUsuarioAsync(id);
            if (!response.Success)
                return NotFound(response.Message);
            Ok(response);

            return RedirectToAction("Index", "Usuario");
        }
    }
}
