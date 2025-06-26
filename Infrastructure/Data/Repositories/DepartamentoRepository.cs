using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using ProjetoAcoesSustentaveis.Infrastructure.Data.AppContext;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projeto_SCFII.Infrastructure.Data.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly AppDbContext _context;

        public DepartamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<Departamento?> GetByIdAsync(int id)
        {
            return await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
