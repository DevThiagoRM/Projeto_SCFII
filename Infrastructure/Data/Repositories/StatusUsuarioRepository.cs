using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using ProjetoAcoesSustentaveis.Infrastructure.Data.AppContext;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projeto_SCFII.Infrastructure.Data.Repositories
{
    public class StatusUsuarioRepository : IStatusUsuarioRepository
    {
        private readonly AppDbContext _context;

        public StatusUsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StatusUsuario>> GetAllAsync()
        {
            return await _context.StatusUsuarios.ToListAsync();
        }

        public async Task<StatusUsuario?> GetByIdAsync(int id)
        {
            return await _context.StatusUsuarios.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
