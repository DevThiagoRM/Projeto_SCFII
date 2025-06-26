using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Repositories
{
    public interface IStatusUsuarioRepository
    {
        Task<IEnumerable<StatusUsuario>> GetAllAsync();
        Task<StatusUsuario?> GetByIdAsync(int id);
    }
}
