using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Domain.Entities
{
    public class Deficiencia
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? CID { get; set; }

        public ICollection<UsuarioDeficiencia> UsuarioDeficiencia { get; set; } = new HashSet<UsuarioDeficiencia>();
    }
}
