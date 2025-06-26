using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Services
{
    public interface ICargoService
    {
        Task<ResponseDTO<IEnumerable<Cargo>>> GetAllAsync();
        Task<ResponseDTO<Cargo>> GetByIdAsync(int id);
    }
}
