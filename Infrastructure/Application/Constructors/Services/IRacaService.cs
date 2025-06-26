using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Services
{
    public interface IRacaService
    {
        Task<ResponseDTO<IEnumerable<Raca>>> GetAllAsync();
        Task<ResponseDTO<Raca>> GetByIdAsync(int id);
    }
}
