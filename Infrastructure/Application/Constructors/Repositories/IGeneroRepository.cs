using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Repositories
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> GetAllAsync();
        Task<Genero?> GetByIdAsync(int id);
    }
}
