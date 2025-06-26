using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using ProjetoAcoesSustentaveis.Infrastructure.Data.AppContext;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projeto_SCFII.Infrastructure.Data.Repositories
{
    public class RacaRepository : IRacaRepository
    {
        private readonly AppDbContext _context;

        public RacaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Raca>> GetAllAsync()
        {
            return await _context.Racas.ToListAsync();
        }

        public async Task<Raca?> GetByIdAsync(int id)
        {
            return await _context.Racas.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
