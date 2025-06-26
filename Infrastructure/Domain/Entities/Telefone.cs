namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class Telefone
    {
        public int Id { get; set; }
        public string? NumeroTelefone { get; set; }

        public TipoTelefone? TipoTelefone { get; set; }
        public int TipoTelefoneId { get; set; }

        public Usuario? Usuario { get; set; }
        public int UsuarioId { get; set; }

    }
}
