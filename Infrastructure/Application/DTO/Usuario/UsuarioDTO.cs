using Projeto_SCFII.Infrastructure.Domain.Entities;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.DTO.Usuario
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NomeCompleto => $"{Nome} {Sobrenome}";
        public string? Email { get; set; }

        public int CargoId { get; set; }
        public string? NomeCargo { get; set; }

        public int DepartamentoId { get; set; }
        public string? NomeDepartamento { get; set; }

        public int RacaId { get; set; }
        public string? NomeRaca { get; set; }

        public bool PossuiDeficiencia { get; set; }
        public ICollection<UsuarioDeficiencia>? UsuarioDeficiencia { get; set; } = new HashSet<UsuarioDeficiencia>();

        public int GeneroId { get; set; }
        public string? NomeGenero { get; set; }

        public int StatusUsuarioId { get; set; }
        public string? NomeStatusUsuario { get; set; }

        public int TipoUsuarioId { get; set; }
        public string? NomeTipoUsuario { get; set; }

        public ICollection<UsuarioEndereco>? UsuarioEndereco { get; set; } = new HashSet<UsuarioEndereco>();
        public ICollection<UsuarioTelefone>? UsuarioTelefone { get; set; } = new HashSet<UsuarioTelefone>();

        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
        public bool Deleted { get; set; }
    }
}
