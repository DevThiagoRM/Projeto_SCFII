using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Projeto_SCFII.Infrastructure.Data.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly ILogger<CargoService> _logger;

        public CargoService(ICargoRepository cargoRepository, ILogger<CargoService> logger)
        {
            _cargoRepository = cargoRepository;
            _logger = logger;
        }

        public async Task<ResponseDTO<IEnumerable<Cargo>>> GetAllAsync()
        {
            try
            {
                var cargos = await _cargoRepository.GetAllAsync();
                return ResponseDTO<IEnumerable<Cargo>>.CreateSuccess("Cargos encontrados com sucesso.", cargos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os cargos.");
                return ResponseDTO<IEnumerable<Cargo>>.CreateError("Erro ao buscar cargos.");
            }
        }

        public async Task<ResponseDTO<Cargo>> GetByIdAsync(int id)
        {
            try
            {
                var cargo = await _cargoRepository.GetByIdAsync(id);
                if (cargo == null)
                    return ResponseDTO<Cargo>.CreateError("Cargo não encontrado.");

                return ResponseDTO<Cargo>.CreateSuccess("Cargo encontrado com sucesso.", cargo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar cargo com ID {id}.");
                return ResponseDTO<Cargo>.CreateError("Erro ao buscar cargo.");
            }
        }
    }
}
