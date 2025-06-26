using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Services
{
    public class StatusUsuarioService : IStatusUsuarioService
    {
        private readonly IStatusUsuarioRepository _statusUsuarioRepository;
        private readonly ILogger<StatusUsuarioService> _logger;

        public StatusUsuarioService(IStatusUsuarioRepository statusUsuarioRepository, ILogger<StatusUsuarioService> logger)
        {
            _statusUsuarioRepository = statusUsuarioRepository;
            _logger = logger;
        }

        public async Task<ResponseDTO<IEnumerable<StatusUsuario>>> GetAllAsync()
        {
            try
            {
                var racas = await _statusUsuarioRepository.GetAllAsync();
                return ResponseDTO<IEnumerable<StatusUsuario>>.CreateSuccess("Raças encontradas com sucesso.", racas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos as raças.");
                return ResponseDTO<IEnumerable<StatusUsuario>>.CreateError("Erro ao buscar raças.");
            }
        }

        public async Task<ResponseDTO<StatusUsuario>> GetByIdAsync(int id)
        {
            try
            {
                var raca = await _statusUsuarioRepository.GetByIdAsync(id);
                if (raca == null)
                    return ResponseDTO<StatusUsuario>.CreateError("Raça não encontrada.");

                return ResponseDTO<StatusUsuario>.CreateSuccess("Raça encontrada com sucesso.", raca);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar raça com ID {id}.");
                return ResponseDTO<StatusUsuario>.CreateError("Erro ao buscar raça.");
            }
        }
    }
}
