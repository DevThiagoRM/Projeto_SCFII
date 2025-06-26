namespace ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities
{
    public class Departamento
    {
        public int Id { get; set; }
        public string? NomeDepartamento { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();

    }
}
