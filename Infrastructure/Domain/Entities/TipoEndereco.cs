namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class TipoEndereco
    {
        public int Id { get; set; }
        public string? TipoDeEndereco { get; set; }
        public ICollection<Endereco> Enderecos { get; set; } = new HashSet<Endereco>();
    }
}
