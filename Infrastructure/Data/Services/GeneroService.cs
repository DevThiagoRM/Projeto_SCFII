using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly ILogger<GeneroService> _logger;

        public GeneroService(IGeneroRepository generoRepository, ILogger<GeneroService> logger)
        {
            _generoRepository = generoRepository;
            _logger = logger;
        }

        public async Task<ResponseDTO<IEnumerable<Genero>>> GetAllAsync()
        {
            try
            {
                var generos = await _generoRepository.GetAllAsync();
                return ResponseDTO<IEnumerable<Genero>>.CreateSuccess("Gêneros encontrados com sucesso.", generos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os gêneros.");
                return ResponseDTO<IEnumerable<Genero>>.CreateError("Erro ao buscar gêneros.");
            }
        }

        public async Task<ResponseDTO<Genero>> GetByIdAsync(int id)
        {
            try
            {
                var cargo = await _generoRepository.GetByIdAsync(id);
                if (cargo == null)
                    return ResponseDTO<Genero>.CreateError("Gênero não encontrado.");

                return ResponseDTO<Genero>.CreateSuccess("Gênero encontrado com sucesso.", cargo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar gênero com ID {id}.");
                return ResponseDTO<Genero>.CreateError("Erro ao buscar gênero.");
            }
        }
    }
}
