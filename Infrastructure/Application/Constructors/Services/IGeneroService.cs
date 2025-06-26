using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Services
{
    public interface IGeneroService
    {
        Task<ResponseDTO<IEnumerable<Genero>>> GetAllAsync();
        Task<ResponseDTO<Genero>> GetByIdAsync(int id);
    }
}
