using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Digite o login")]
        public string UserLogin { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
