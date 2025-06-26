namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        public string? NomeGenero { get; set; }
        public string?  Descricao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    }
}
