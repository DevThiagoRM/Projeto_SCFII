namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class StatusUsuario
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    }
}
