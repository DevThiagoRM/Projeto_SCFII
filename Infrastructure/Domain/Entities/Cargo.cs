namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public string? NomeCargo { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    }
}
