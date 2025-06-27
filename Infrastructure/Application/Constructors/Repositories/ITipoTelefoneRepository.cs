using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Repositories
{
    public interface ITipoTelefoneRepository
    {
        Task<IEnumerable<TipoTelefone>> GetAllAsync();
        Task<TipoTelefone?> GetByIdAsync(int id);
    }
}
