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
        public string? CEP { get; set; }
        public string? Complemento { get; set; }
        public string? PontoReferencia { get; set; }

        public Usuario? Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}
