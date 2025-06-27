using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Services
{
    public interface ITipoTelefoneService
    {
        Task<ResponseDTO<IEnumerable<TipoTelefone>>> GetAllAsync();
        Task<ResponseDTO<TipoTelefone>> GetByIdAsync(int id);
    }
}
