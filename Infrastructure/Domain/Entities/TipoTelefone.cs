namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class TipoTelefone
    {
        public int Id { get; set; }
        public string? TipoDeTelefone { get; set; }
        public ICollection<Telefone> Telefones { get; set; } = new HashSet<Telefone>();
    }
}
