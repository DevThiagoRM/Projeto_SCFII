namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class Telefone
    {
        public int Id { get; set; }
        public string? NumeroTelefone { get; set; }
        public ICollection<UsuarioTelefone>? UsuarioTelefone { get; set; } = new HashSet<UsuarioTelefone>();
        public TipoTelefone? TipoTelefone { get; set; }
        public int TipoTelefoneId { get; set; }
    }
}
