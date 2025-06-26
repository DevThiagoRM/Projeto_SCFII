using System.ComponentModel.DataAnnotations;

namespace Projeto_SCFII.Infrastructure.Application.DTO.Usuario
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;
    }
}
