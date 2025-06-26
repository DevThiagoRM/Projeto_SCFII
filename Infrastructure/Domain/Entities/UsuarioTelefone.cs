namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class UsuarioTelefone
    {
        public Usuario? Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Telefone? Telefone { get; set; }
        public int TelefoneId { get; set; }
    }
}
