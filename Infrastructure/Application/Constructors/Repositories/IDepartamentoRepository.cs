using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> GetAllAsync();
        Task<Departamento?> GetByIdAsync(int id);
    }
}
