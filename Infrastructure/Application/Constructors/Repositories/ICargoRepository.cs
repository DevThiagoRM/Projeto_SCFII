using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Repositories
{
    public interface ICargoRepository
    {
        Task<IEnumerable<Cargo>> GetAllAsync();
        Task<Cargo?> GetByIdAsync(int id);
    }
}
