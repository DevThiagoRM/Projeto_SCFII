using Microsoft.EntityFrameworkCore;
using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using ProjetoAcoesSustentaveis.Infrastructure.Data.AppContext;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly AppDbContext _context;

        public GeneroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genero>> GetAllAsync()
        {
            return await _context.Generos.ToListAsync();
        }

        public async Task<Genero?> GetByIdAsync(int id)
        {
            return await _context.Generos.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
