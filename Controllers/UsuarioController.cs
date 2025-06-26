using Microsoft.AspNetCore.Mvc;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Usuario;
using Projeto_SCFII.Infrastructure.Application.Filters;

namespace Projeto_SCFII.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
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

        [HttpPost("filtro")]
        public async Task<IActionResult> GetByFiltro([FromBody] UsuarioFiltro filtro)
        {
            var response = await _usuarioService.GetUsuariosByFiltroAsync(filtro);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDTO usuarioCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _usuarioService.CreateUsuarioAsync(usuarioCreateDto);
            if (!response.Success || response.Data == null)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _usuarioService.DeleteUsuarioAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response);
        }
    }
}
