using Projeto_SCFII.Infrastructure.Domain.Entities;

namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NomeCompleto => $"{Nome} {Sobrenome}";
        public string? Email { get; set; }
        public string? Senha { get; set; }

        public Cargo? Cargo { get; set; }
        public int CargoId { get; set; }

        public Departamento? Departamento { get; set; }
        public int DepartamentoId { get; set; }

        public Raca? Raca { get; set; }
        public int RacaId { get; set; }

        public Genero? Genero { get; set; }
        public int GeneroId { get; set; }

        public bool PossuiDeficiencia { get; set; }

        public ICollection<UsuarioDeficiencia> UsuarioDeficiencia { get; set; } = new HashSet<UsuarioDeficiencia>();
        public ICollection<UsuarioEndereco>? UsuarioEndereco { get; set; } = new HashSet<UsuarioEndereco>();
        public ICollection<UsuarioTelefone>? UsuarioTelefone { get; set; } = new HashSet<UsuarioTelefone>();

        public StatusUsuario? StatusUsuario { get; set; }
        public int StatusUsuarioId { get; set; }

        public TipoUsuario? TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }

        public Usuario? CriadoPor { get; set; }
        public int? CriadoPorId { get; set; }
        public DateTime DataCriacao { get; set; }

        public ICollection<Usuario> UsuariosCriados { get; set; } = new HashSet<Usuario>();
        public ICollection<Usuario> UsuariosAtualizados { get; set; } = new HashSet<Usuario>();

        public Usuario? AtualizadoPor { get; set; }
        public int? AtualizadoPorId { get; set; }
        public DateTime UltimaAtualizacao { get; set; }

        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }

        public bool Deleted { get; set; }
    }
}
