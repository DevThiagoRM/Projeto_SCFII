namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class Raca
    {
        public int Id { get; set; }
        public string? NomeRaca { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    }
}
