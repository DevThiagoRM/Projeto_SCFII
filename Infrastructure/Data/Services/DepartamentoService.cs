using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly ILogger<DepartamentoService> _logger;

        public DepartamentoService(IDepartamentoRepository departamentoRepository, ILogger<DepartamentoService> logger)
        {
            _departamentoRepository = departamentoRepository;
            _logger = logger;
        }

        public async Task<ResponseDTO<IEnumerable<Departamento>>> GetAllAsync()
        {
            try
            {
                var departamentos = await _departamentoRepository.GetAllAsync();
                return ResponseDTO<IEnumerable<Departamento>>.CreateSuccess("Departamentos encontrados com sucesso.", departamentos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os departamentos.");
                return ResponseDTO<IEnumerable<Departamento>>.CreateError("Erro ao buscar departamentos.");
            }
        }

        public async Task<ResponseDTO<Departamento>> GetByIdAsync(int id)
        {
            try
            {
                var departamento = await _departamentoRepository.GetByIdAsync(id);
                if (departamento == null)
                    return ResponseDTO<Departamento>.CreateError("Departamento não encontrado.");

                return ResponseDTO<Departamento>.CreateSuccess("Departamento encontrado com sucesso.", departamento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar departamento com ID {id}.");
                return ResponseDTO<Departamento>.CreateError("Erro ao buscar departamento.");
            }
        }
    }
}
