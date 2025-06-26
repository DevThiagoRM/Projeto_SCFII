using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using ProjetoAcoesSustentaveis.Infrastructure.Data.AppContext;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projeto_SCFII.Infrastructure.Data.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly AppDbContext _context;

        public TipoUsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoUsuario>> GetAllAsync()
        {
            return await _context.TiposUsuario.ToListAsync();
        }

        public async Task<TipoUsuario?> GetByIdAsync(int id)
        {
            return await _context.TiposUsuario.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
