using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class RedefinirSenha
    {
        [Required(ErrorMessage = "Digite o login")]
        public string UserLogin { get; set; }
        [Required(ErrorMessage = "Digite o email")]
        public string Email { get; set; }
    }
}
