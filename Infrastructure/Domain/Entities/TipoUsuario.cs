namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string? TipoDeUsuario { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    }
}
