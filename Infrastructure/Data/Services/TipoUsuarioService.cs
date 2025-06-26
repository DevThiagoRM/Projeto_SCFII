using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;
        private readonly ILogger<TipoUsuarioService> _logger;

        public TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository, ILogger<TipoUsuarioService> logger)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
            _logger = logger;
        }

        public async Task<ResponseDTO<IEnumerable<TipoUsuario>>> GetAllAsync()
        {
            try
            {
                var tiposUsuario = await _tipoUsuarioRepository.GetAllAsync();
                return ResponseDTO<IEnumerable<TipoUsuario>>.CreateSuccess("Tipos de usuário encontrados com sucesso.", tiposUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar tipos de usuário.");
                return ResponseDTO<IEnumerable<TipoUsuario>>.CreateError("Erro ao buscar tipos de usuário.");
            }
        }

        public async Task<ResponseDTO<TipoUsuario>> GetByIdAsync(int id)
        {
            try
            {
                var tipoUsuario = await _tipoUsuarioRepository.GetByIdAsync(id);
                if (tipoUsuario == null)
                    return ResponseDTO<TipoUsuario>.CreateError("Tipo de usuário não encontrado.");

                return ResponseDTO<TipoUsuario>.CreateSuccess("Tipo de usuário encontrado com sucesso.", tipoUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar tipo de usuário com ID {id}.");
                return ResponseDTO<TipoUsuario>.CreateError("Erro ao buscar tipo de usuário.");
            }
        }
    }
}
