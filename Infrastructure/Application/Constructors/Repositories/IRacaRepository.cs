using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Repositories
{
    public interface IRacaRepository
    {
        Task<IEnumerable<Raca>> GetAllAsync();
        Task<Raca?> GetByIdAsync(int id);
    }
}
