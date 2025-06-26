using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Microsoft.EntityFrameworkCore;
using ProjetoAcoesSustentaveis.Infrastructure.Data.AppContext;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly AppDbContext _context;

        public CargoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cargo>> GetAllAsync()
        {
            return await _context.Cargos.ToListAsync();
        }

        public async Task<Cargo?> GetByIdAsync(int id)
        {
            return await _context.Cargos.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
