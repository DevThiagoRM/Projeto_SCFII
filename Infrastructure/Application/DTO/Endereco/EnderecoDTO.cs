namespace Projeto_SCFII.Infrastructure.Application.DTO.Endereco
{
    public class EnderecoDTO
    {
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? CEP { get; set; }
        public string? Complemento { get; set; }
        public string? PontoReferencia { get; set; }
        public int TipoEnderecoId { get; set; }
        public string? TipoEndereco { get; set; }
    }
}
