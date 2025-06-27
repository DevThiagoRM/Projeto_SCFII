using Microsoft.EntityFrameworkCore;
using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using ProjetoAcoesSustentaveis.Infrastructure.Data.AppContext;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Repositories
{
    public class TipoTelefoneRepository : ITipoTelefoneRepository
    {
        private readonly AppDbContext _context;

        public TipoTelefoneRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoTelefone>> GetAllAsync()
        {
            return await _context.TiposTelefone.ToListAsync();
        }

        public async Task<TipoTelefone?> GetByIdAsync(int id)
        {
            return await _context.TiposTelefone.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
