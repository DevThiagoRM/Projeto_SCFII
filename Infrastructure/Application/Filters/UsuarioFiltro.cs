namespace Projeto_SCFII.Infrastructure.Application.Filters
{
    public class UsuarioFiltro
    {
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public int? CargoId { get; set; }
        public int? DepartamentoId { get; set; }
        public int? RacaId { get; set; }
        public int? GeneroId { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
    }
}
