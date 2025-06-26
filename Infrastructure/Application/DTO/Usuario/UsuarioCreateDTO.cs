using Projeto_SCFII.Infrastructure.Application.DTO.Endereco;
using Projeto_SCFII.Infrastructure.Application.DTO.Telefone;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Projeto_SCFII.Infrastructure.Application.DTO.Usuario
{
    public class UsuarioCreateDTO
    {
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NomeCompleto => $"{Nome} {Sobrenome}";
        public string? Email { get; set; }
        public string? Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public string? ConfirmarSenha { get; set; }

        public int CargoId { get; set; }
        public string? NomeCargo { get; set; }

        public int DepartamentoId { get; set; }
        public string? NomeDepartamento { get; set; }

        public int RacaId { get; set; }
        public string? NomeRaca { get; set; }

        public bool PossuiDeficiencia { get; set; }
        public string? CID { get; set; }

        public int GeneroId { get; set; }
        public string? NomeGenero { get; set; }

        public int StatusUsuarioId { get; set; }
        public string? NomeStatusUsuario { get; set; }

        public int TipoUsuarioId { get; set; }
        public string? NomeTipoUsuario { get; set; }

        public EnderecoDTO? Endereco { get; set; }
        public TelefoneDTO? Telefone { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public bool Deleted { get; set; }
    }
}
