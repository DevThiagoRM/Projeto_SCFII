using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using Projeto_SCFII.Infrastructure.Application.DTO.Usuario;
using Projeto_SCFII.Infrastructure.Application.Filters;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Services
{
    public interface IUsuarioService
    {
        Task<ResponseDTO<IEnumerable<UsuarioDTO>>> GetAllUsuariosAsync();
        Task<ResponseDTO<IEnumerable<UsuarioDTO>>> GetUsuariosByFiltroAsync(UsuarioFiltro filtro);

        Task<ResponseDTO<UsuarioDTO?>> GetUsuarioByIdAsync(int id);
        Task<ResponseDTO<UsuarioDTO?>> GetUsuarioByEmailAsync(string email);

        Task<ResponseDTO<UsuarioDTO>> CreateUsuarioAsync(UsuarioCreateDTO usuarioCreateDto);
        Task<ResponseDTO<UsuarioDTO>> UpdateUsuarioAsync(int id, UsuarioUpdateDTO usuarioUpdateDto);
        Task<ResponseDTO<bool>> DeleteUsuarioAsync(int id);

        Task<ResponseDTO<bool>> UsuarioExistsAsync(int id);
        Task<ResponseDTO<bool>> UsuarioEmailExistsAsync(string email);

        Task<ResponseDTO<UsuarioDTO?>> ValidarLoginAsync(string email, string senha);
    }
}
