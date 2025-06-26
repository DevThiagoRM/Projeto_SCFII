using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Services
{
    public interface IStatusUsuarioService
    {
        Task<ResponseDTO<IEnumerable<StatusUsuario>>> GetAllAsync();
        Task<ResponseDTO<StatusUsuario>> GetByIdAsync(int id);
    }
}
