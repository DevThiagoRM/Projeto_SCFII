using Microsoft.EntityFrameworkCore;
using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using Projeto_SCFII.Infrastructure.Application.DTO.Usuario;
using Projeto_SCFII.Infrastructure.Application.Filters;
using ProjetoAcoesSustentaveis.Infrastructure.Data.AppContext;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            usuario.DataCriacao = DateTime.UtcNow;
            usuario.UltimaAtualizacao = DateTime.UtcNow;
            usuario.Deleted = false;

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;
            usuario.Deleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios
                .Where(u => !u.Deleted)
                .Include(u => u.Cargo)
                .Include(u => u.Departamento)
                .Include(u => u.Raca)
                .Include(u => u.Genero)
                .Include(u => u.StatusUsuario)
                .Include(u => u.TipoUsuario)
                .ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id && !u.Deleted);
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosByFiltroAsync(UsuarioFiltro filtro)
        {
            IQueryable<Usuario> query = _context.Usuarios.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro.Nome))
                query = query.Where(u => u.Nome!.Contains(filtro.Nome));

            if (!string.IsNullOrWhiteSpace(filtro.Sobrenome))
                query = query.Where(u => u.Sobrenome!.Contains(filtro.Sobrenome));

            if (filtro.CargoId.HasValue)
                query = query.Where(u => u.CargoId == filtro.CargoId.Value);

            if (filtro.DepartamentoId.HasValue)
                query = query.Where(u => u.DepartamentoId == filtro.DepartamentoId.Value);

            if (filtro.RacaId.HasValue)
                query = query.Where(u => u.RacaId == filtro.RacaId.Value);

            if (filtro.GeneroId.HasValue)
                query = query.Where(u => u.GeneroId == filtro.GeneroId.Value);

            if (filtro.DataAdmissao.HasValue)
                query = query.Where(u => u.DataAdmissao.Date == filtro.DataAdmissao.Value.Date);

            if (filtro.Deleted.HasValue)
                query = query.Where(u => u.Deleted == filtro.Deleted.Value);

            return await query.ToListAsync();
        }

        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            usuario.UltimaAtualizacao = DateTime.UtcNow;
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UsuarioEmailExistsAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UsuarioExistsAsync(int id)
        {
            return await _context.Usuarios.AnyAsync(u => u.Id == id);
        }

        public async Task<Usuario?> GetUsuarioCompletoPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && !u.Deleted);
        }

        public async Task<ResponseDTO<DashboardDTO>> GetDashboardDataAsync()
        {
            var usuarios = await _context.Usuarios
                                .Include(u => u.Raca)
                                .Include(u => u.Genero)
                                .Include(u => u.StatusUsuario)
                                .ToListAsync();

            var dashboard = new DashboardDTO
            {
                TotalUsuarios = usuarios.Count,
                PorRaca = usuarios
                    .GroupBy(u => u.Raca.NomeRaca)
                    .Select(g => new ItemDashboardDTO
                    {
                        Nome = g.Key,
                        Quantidade = g.Count(),
                        Percentual = (decimal)g.Count() / usuarios.Count * 100
                    })
                    .OrderByDescending(x => x.Quantidade)
                    .ToList(),

                PorGenero = usuarios
                    .GroupBy(u => u.Genero.NomeGenero)
                    .Select(g => new ItemDashboardDTO
                    {
                        Nome = g.Key,
                        Quantidade = g.Count(),
                        Percentual = (decimal)g.Count() / usuarios.Count * 100
                    })
                    .OrderByDescending(x => x.Quantidade)
                    .ToList(),

                PorStatus = usuarios
                    .GroupBy(u => u.StatusUsuario.Status)
                    .Select(g => new ItemDashboardDTO
                    {
                        Nome = g.Key,
                        Quantidade = g.Count(),
                        Percentual = (decimal)g.Count() / usuarios.Count * 100
                    })
                    .OrderByDescending(x => x.Quantidade)
                    .ToList()
            };

            return new ResponseDTO<DashboardDTO>(true, "Dados do dashboard obtidos com sucesso", dashboard);
        }

    }
}
