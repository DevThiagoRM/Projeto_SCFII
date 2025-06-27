namespace Projeto_SCFII.Infrastructure.Application.DTO.Usuario
{
    public class DashboardDTO
    {
        public int TotalUsuarios { get; set; }
        public List<ItemDashboardDTO>? PorRaca { get; set; }
        public List<ItemDashboardDTO>? PorGenero { get; set; }
        public List<ItemDashboardDTO>? PorDeficiencia { get; set; }
        public List<ItemDashboardDTO>? PorStatus { get; set; }
    }

    public class ItemDashboardDTO
    {
        public string? Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Percentual { get; set; }
    }
}
