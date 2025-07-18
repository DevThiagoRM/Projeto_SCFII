﻿namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NomeCompleto => $"{Nome} {Sobrenome}";
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public bool PossuiDeficiencia { get; set; }
        public string? CID { get; set; }

        public Cargo? Cargo { get; set; }
        public int CargoId { get; set; }

        public Departamento? Departamento { get; set; }
        public int DepartamentoId { get; set; }

        public Raca? Raca { get; set; }
        public int RacaId { get; set; }

        public Genero? Genero { get; set; }
        public int GeneroId { get; set; }

        public Endereco? Endereco { get; set; }
        public Telefone? Telefone { get; set; }

        public StatusUsuario? StatusUsuario { get; set; }
        public int StatusUsuarioId { get; set; }

        public TipoUsuario? TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }

        public bool Deleted { get; set; }
    }
}
