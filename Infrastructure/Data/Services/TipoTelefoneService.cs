using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Services
{
    public class TipoTelefoneService : ITipoTelefoneService
    {
        private readonly ITipoTelefoneRepository _tipoUsuarioRepository;
        private readonly ILogger<TipoTelefoneService> _logger;

        public TipoTelefoneService(ITipoTelefoneRepository tipoTelefoneRepository, ILogger<TipoTelefoneService> logger)
        {
            _tipoUsuarioRepository = tipoTelefoneRepository;
            _logger = logger;
        }

        public async Task<ResponseDTO<IEnumerable<TipoTelefone>>> GetAllAsync()
        {
            try
            {
                var tiposTelefone = await _tipoUsuarioRepository.GetAllAsync();
                return ResponseDTO<IEnumerable<TipoTelefone>>.CreateSuccess("Tipos de telefones encontrados com sucesso.", tiposTelefone);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar tipos de telefones.");
                return ResponseDTO<IEnumerable<TipoTelefone>>.CreateError("Erro ao buscar tipos de telefones.");
            }
        }

        public async Task<ResponseDTO<TipoTelefone>> GetByIdAsync(int id)
        {
            try
            {
                var tipoTelefone = await _tipoUsuarioRepository.GetByIdAsync(id);
                if (tipoTelefone == null)
                    return ResponseDTO<TipoTelefone>.CreateError("Tipo de telefone não encontrado.");

                return ResponseDTO<TipoTelefone>.CreateSuccess("Tipo de telefone encontrado com sucesso.", tipoTelefone);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar tipo de telefone com ID {id}.");
                return ResponseDTO<TipoTelefone>.CreateError("Erro ao buscar tipo de telefone.");
            }
        }
    }
}
