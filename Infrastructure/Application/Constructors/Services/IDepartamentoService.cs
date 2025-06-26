using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Services
{
    public interface IDepartamentoService
    {
        Task<ResponseDTO<IEnumerable<Departamento>>> GetAllAsync();
        Task<ResponseDTO<Departamento>> GetByIdAsync(int id);
    }
}
