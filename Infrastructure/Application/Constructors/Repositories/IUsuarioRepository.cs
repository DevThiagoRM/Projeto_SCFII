using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using Projeto_SCFII.Infrastructure.Application.DTO.Usuario;
using Projeto_SCFII.Infrastructure.Application.Filters;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<IEnumerable<Usuario>> GetUsuariosByFiltroAsync(UsuarioFiltro filtro);

        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task<Usuario?> GetUsuarioByEmailAsync(string email);
        Task<Usuario?> GetUsuarioCompletoPorEmailAsync(string email);
        Task<ResponseDTO<DashboardDTO>> GetDashboardDataAsync();


        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
        Task<bool> DeleteUsuarioAsync(int id);

        Task<bool> UsuarioExistsAsync(int id);
        Task<bool> UsuarioEmailExistsAsync(string email);
    }
}
