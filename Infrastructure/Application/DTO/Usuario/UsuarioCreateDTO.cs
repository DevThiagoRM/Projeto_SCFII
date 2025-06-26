using Projeto_SCFII.Infrastructure.Domain.Entities;
using ProjetoAcoesSustentaveis.Infrastructure.Domain.Entities;

namespace Projeto_SCFII.Infrastructure.Application.DTO.Usuario
{
    public class UsuarioCreateDTO
    {
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string ConfirmarSenha { get; set; } = null!;

        public int CargoId { get; set; }
        public int DepartamentoId { get; set; }
        public int RacaId { get; set; }
        public int GeneroId { get; set; }
        public int StatusUsuarioId { get; set; }
        public int TipoUsuarioId { get; set; }

        public bool PossuiDeficiencia { get; set; }
        public List<UsuarioDeficienciaDTO> Deficiencias { get; set; } = new List<UsuarioDeficienciaDTO>();

        public List<UsuarioEnderecoDTO> Enderecos { get; set; } = new List<UsuarioEnderecoDTO>();
        public List<UsuarioTelefoneDTO> Telefones { get; set; } = new List<UsuarioTelefoneDTO>();


        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
    }
}
