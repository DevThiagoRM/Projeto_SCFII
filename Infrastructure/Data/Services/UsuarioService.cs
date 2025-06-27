using Azure;
using Microsoft.EntityFrameworkCore;
using Projeto_SCFII.Infrastructure.Application.Constructors.Repositories;
using Projeto_SCFII.Infrastructure.Application.Constructors.Services;
using Projeto_SCFII.Infrastructure.Application.DTO.Endereco;
using Projeto_SCFII.Infrastructure.Application.DTO.Shared;
using Projeto_SCFII.Infrastructure.Application.DTO.Telefone;
using Projeto_SCFII.Infrastructure.Application.DTO.Usuario;
using Projeto_SCFII.Infrastructure.Application.Filters;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Data.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        public async Task<ResponseDTO<UsuarioDTO>> CreateUsuarioAsync(UsuarioCreateDTO usuarioCreateDto)
        {
            try
            {
                if (await _usuarioRepository.UsuarioEmailExistsAsync(usuarioCreateDto.Email!))
                    return ResponseDTO<UsuarioDTO>.CreateError("Email já cadastrado.");

                if (usuarioCreateDto.Senha != usuarioCreateDto.ConfirmarSenha)
                    return ResponseDTO<UsuarioDTO>.CreateError("As senhas não coincidem.");

                var usuario = new Usuario
                {
                    Nome = usuarioCreateDto.Nome,
                    Sobrenome = usuarioCreateDto.Sobrenome,
                    Email = usuarioCreateDto.Email,
                    Senha = BCrypt.Net.BCrypt.HashPassword(usuarioCreateDto.Senha),
                    CargoId = usuarioCreateDto.CargoId,
                    DepartamentoId = usuarioCreateDto.DepartamentoId,
                    RacaId = usuarioCreateDto.RacaId,
                    GeneroId = usuarioCreateDto.GeneroId,
                    StatusUsuarioId = usuarioCreateDto.StatusUsuarioId,
                    TipoUsuarioId = usuarioCreateDto.TipoUsuarioId,
                    PossuiDeficiencia = usuarioCreateDto.PossuiDeficiencia,
                    CID = usuarioCreateDto.CID,
                    Endereco = usuarioCreateDto.Endereco != null ? new Endereco
                    {
                        Logradouro = usuarioCreateDto.Endereco.Logradouro,
                        Numero = usuarioCreateDto.Endereco.Numero,
                        Complemento = usuarioCreateDto.Endereco.Complemento,
                        Bairro = usuarioCreateDto.Endereco.Bairro,
                        Cidade = usuarioCreateDto.Endereco.Cidade,
                        UF = usuarioCreateDto.Endereco.UF,
                        CEP = usuarioCreateDto.Endereco.CEP,
                    } : null,
                    Telefone = usuarioCreateDto.Telefone != null ? new Telefone
                    {
                        NumeroTelefone = usuarioCreateDto.Telefone.NumeroTelefone,
                        TipoTelefoneId = usuarioCreateDto.Telefone.TipoTelefoneId,
                    } : null
                };


                if (usuarioCreateDto.Senha != usuarioCreateDto.ConfirmarSenha)
                    return ResponseDTO<UsuarioDTO>.CreateError("As senhas não coincidem.");

                var criado = await _usuarioRepository.CreateUsuarioAsync(usuario);
                var dto = MapToUsuarioDTO(criado);
                return ResponseDTO<UsuarioDTO>.CreateSuccess("Usuário criado com sucesso.", dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuário");
                return ResponseDTO<UsuarioDTO>.CreateError("Erro interno ao criar usuário.");
            }
        }

        public async Task<ResponseDTO<bool>> DeleteUsuarioAsync(int id)
        {
            try
            {
                if (!await _usuarioRepository.UsuarioExistsAsync(id))
                    return ResponseDTO<bool>.CreateError("Usuário não encontrado.");

                var resultado = await _usuarioRepository.DeleteUsuarioAsync(id);
                if (resultado)
                    return ResponseDTO<bool>.CreateSuccess("Usuário excluído com sucesso.", true);
                else
                    return ResponseDTO<bool>.CreateError("Falha ao excluir usuário.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir usuário");
                return ResponseDTO<bool>.CreateError("Erro interno ao excluir usuário.");
            }
        }

        public async Task<ResponseDTO<IEnumerable<UsuarioDTO>>> GetAllUsuariosAsync()
        {
            try
            {
                var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
                var dtos = usuarios
                    .Where(u => u != null)
                    .Select(u => MapToUsuarioDTO(u!));
                return ResponseDTO<IEnumerable<UsuarioDTO>>.CreateSuccess("Lista de usuários obtida.", dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter lista de usuários");
                return ResponseDTO<IEnumerable<UsuarioDTO>>.CreateError("Erro interno ao obter usuários.");
            }
        }

        public async Task<ResponseDTO<UsuarioDTO?>> GetUsuarioByEmailAsync(string email)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioByEmailAsync(email);
                if (usuario == null)
                    return ResponseDTO<UsuarioDTO?>.CreateError("Usuário não encontrado.");

                return ResponseDTO<UsuarioDTO?>.CreateSuccess("Usuário encontrado.", MapToUsuarioDTO(usuario));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar usuário por email");
                return ResponseDTO<UsuarioDTO?>.CreateError("Erro interno ao buscar usuário.");
            }
        }

        public async Task<ResponseDTO<UsuarioDTO?>> GetUsuarioByIdAsync(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
                if (usuario == null)
                    return ResponseDTO<UsuarioDTO?>.CreateError("Usuário não encontrado.");

                return ResponseDTO<UsuarioDTO?>.CreateSuccess("Usuário encontrado.", MapToUsuarioDTO(usuario));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar usuário por ID");
                return ResponseDTO<UsuarioDTO?>.CreateError("Erro interno ao buscar usuário.");
            }
        }

        public async Task<ResponseDTO<IEnumerable<UsuarioDTO>>> GetUsuariosByFiltroAsync(UsuarioFiltro filtro)
        {
            try
            {
                var usuarios = await _usuarioRepository.GetUsuariosByFiltroAsync(filtro);
                var dtos = usuarios
                    .Where(u => u != null)
                    .Select(u => MapToUsuarioDTO(u!));
                return ResponseDTO<IEnumerable<UsuarioDTO>>.CreateSuccess("Usuários filtrados obtidos.", dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao filtrar usuários");
                return ResponseDTO<IEnumerable<UsuarioDTO>>.CreateError("Erro interno ao filtrar usuários.");
            }
        }

        public async Task<ResponseDTO<UsuarioDTO>> UpdateUsuarioAsync(int id, UsuarioUpdateDTO usuarioUpdateDto)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
                if (usuario == null)
                    return ResponseDTO<UsuarioDTO>.CreateError("Usuário não encontrado.");

                usuario.Nome = usuarioUpdateDto.Nome;
                usuario.Sobrenome = usuarioUpdateDto.Sobrenome;
                usuario.Email = usuarioUpdateDto.Email;
                usuario.CargoId = usuarioUpdateDto.CargoId;
                usuario.DepartamentoId = usuarioUpdateDto.DepartamentoId;
                usuario.RacaId = usuarioUpdateDto.RacaId;
                usuario.GeneroId = usuarioUpdateDto.GeneroId;
                usuario.StatusUsuarioId = usuarioUpdateDto.StatusUsuarioId;
                usuario.TipoUsuarioId = usuarioUpdateDto.TipoUsuarioId;

                var atualizado = await _usuarioRepository.UpdateUsuarioAsync(usuario);
                return ResponseDTO<UsuarioDTO>.CreateSuccess("Usuário atualizado com sucesso.", MapToUsuarioDTO(atualizado));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar usuário");
                return ResponseDTO<UsuarioDTO>.CreateError("Erro interno ao atualizar usuário.");
            }
        }

        public async Task<ResponseDTO<bool>> UsuarioEmailExistsAsync(string email)
        {
            try
            {
                var exists = await _usuarioRepository.UsuarioEmailExistsAsync(email);
                return ResponseDTO<bool>.CreateSuccess("Verificação concluída.", exists);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao verificar email");
                return ResponseDTO<bool>.CreateError("Erro interno ao verificar email.");
            }
        }

        public async Task<ResponseDTO<bool>> UsuarioExistsAsync(int id)
        {
            try
            {
                var exists = await _usuarioRepository.UsuarioExistsAsync(id);
                return ResponseDTO<bool>.CreateSuccess("Verificação concluída.", exists);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao verificar usuário");
                return ResponseDTO<bool>.CreateError("Erro interno ao verificar usuário.");
            }
        }

        public async Task<ResponseDTO<UsuarioDTO?>> ValidarLoginAsync(string email, string senha)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioCompletoPorEmailAsync(email);
                if (usuario == null)
                    return ResponseDTO<UsuarioDTO?>.CreateError("Usuário não encontrado.");

                bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
                if (!senhaValida)
                    return ResponseDTO<UsuarioDTO?>.CreateError("Senha inválida.");

                return ResponseDTO<UsuarioDTO?>.CreateSuccess("Login válido.", MapToUsuarioDTO(usuario));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao validar login");
                return ResponseDTO<UsuarioDTO?>.CreateError("Erro interno ao validar login.");
            }
        }

        public async Task<ResponseDTO<DashboardDTO>> GetDataDashboardAsync()
        {
            return await _usuarioRepository.GetDashboardDataAsync();
        }

        private UsuarioDTO MapToUsuarioDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Email = usuario.Email,
                CargoId = usuario.CargoId,
                NomeCargo = usuario.Cargo?.NomeCargo,
                DepartamentoId = usuario.DepartamentoId,
                NomeDepartamento = usuario.Departamento?.NomeDepartamento,
                RacaId = usuario.RacaId,
                NomeRaca = usuario.Raca?.NomeRaca,
                GeneroId = usuario.GeneroId,
                NomeGenero = usuario.Genero?.NomeGenero,
                StatusUsuarioId = usuario.StatusUsuarioId,
                NomeStatusUsuario = usuario.StatusUsuario?.Status,
                TipoUsuarioId = usuario.TipoUsuarioId,
                NomeTipoUsuario = usuario.TipoUsuario?.TipoDeUsuario,
                PossuiDeficiencia = usuario.PossuiDeficiencia,
                CID = usuario.CID,
                Endereco = usuario.Endereco != null ? new EnderecoDTO
                {
                    Logradouro = usuario.Endereco.Logradouro,
                    Numero = usuario.Endereco.Numero,
                    Complemento = usuario.Endereco.Complemento,
                    Bairro = usuario.Endereco.Bairro,
                    Cidade = usuario.Endereco.Cidade,
                    UF = usuario.Endereco.UF,
                    CEP = usuario.Endereco.CEP
                } : null,
                Telefone = usuario.Telefone != null ? new TelefoneDTO
                {
                    NumeroTelefone = usuario.Telefone.NumeroTelefone,
                    TipoTelefoneId = usuario.Telefone.TipoTelefoneId,
                    TipoTelefone = usuario.Telefone.TipoTelefone?.TipoDeTelefone
                } : null,
                DataCriacao = usuario.DataCriacao,
                UltimaAtualizacao = usuario.UltimaAtualizacao,
                Deleted = usuario.Deleted
            };
        }
    }
}
