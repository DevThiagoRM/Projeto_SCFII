using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Services
{
    public interface ITipoUsuarioService
    {
        Task<ResponseDTO<IEnumerable<TipoUsuario>>> GetAllAsync();
        Task<ResponseDTO<TipoUsuario>> GetByIdAsync(int id);
    }
}
