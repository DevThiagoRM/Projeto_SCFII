namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class UsuarioEndereco
    {
        public Usuario? Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Endereco? Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}
