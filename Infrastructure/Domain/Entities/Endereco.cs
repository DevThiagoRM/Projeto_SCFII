namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? Referencia { get; set; }
        public ICollection<UsuarioEndereco>? UsuarioEndereco { get; set; } = new HashSet<UsuarioEndereco>();
        public TipoEndereco? TipoEndereco { get; set; }
        public int TipoEnderecoId { get; set; }
    }
}
