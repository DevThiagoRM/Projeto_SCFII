namespace Projeto_SCFII.Infrastructure.Application.DTO.Usuario
{
    public class UsuarioEnderecoDTO
    {
        public int EnderecoId { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? CEP { get; set; }
    }
}
