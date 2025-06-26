namespace Projeto_SCFII.Infrastructure.Application.DTO.Usuario
{
    public class UsuarioUpdateDTO
    {
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int CargoId { get; set; }
        public int DepartamentoId { get; set; }
        public int RacaId { get; set; }
        public int GeneroId { get; set; }
        public int StatusUsuarioId { get; set; }
        public int TipoUsuarioId { get; set; }

        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
    }
}
