using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Domain.Entities
{
    public class UsuarioDeficiencia
    {
        public Usuario? Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Deficiencia? Deficiencia { get; set; }
        public int DeficienciaId { get; set; }
    }
}
