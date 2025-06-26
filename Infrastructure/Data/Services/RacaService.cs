using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Services
{
    public class RacaService :  IRacaService
    {
        private readonly IRacaRepository _racaRepository;
        private readonly ILogger<RacaService> _logger;

        public RacaService(IRacaRepository racaRepository, ILogger<RacaService> logger)
        {
            _racaRepository = racaRepository;
            _logger = logger;
        }

        public async Task<ResponseDTO<IEnumerable<Raca>>> GetAllAsync()
        {
            try
            {
                var racas = await _racaRepository.GetAllAsync();
                return ResponseDTO<IEnumerable<Raca>>.CreateSuccess("Raças encontradas com sucesso.", racas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos as raças.");
                return ResponseDTO<IEnumerable<Raca>>.CreateError("Erro ao buscar raças.");
            }
        }

        public async Task<ResponseDTO<Raca>> GetByIdAsync(int id)
        {
            try
            {
                var raca = await _racaRepository.GetByIdAsync(id);
                if (raca == null)
                    return ResponseDTO<Raca>.CreateError("Raça não encontrada.");

                return ResponseDTO<Raca>.CreateSuccess("Raça encontrada com sucesso.", raca);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar raça com ID {id}.");
                return ResponseDTO<Raca>.CreateError("Erro ao buscar raça.");
            }
        }
    }
}
