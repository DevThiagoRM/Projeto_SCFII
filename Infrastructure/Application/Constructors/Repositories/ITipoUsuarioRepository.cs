using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.Constructors.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<IEnumerable<TipoUsuario>> GetAllAsync();
        Task<TipoUsuario?> GetByIdAsync(int id);
    }
}
