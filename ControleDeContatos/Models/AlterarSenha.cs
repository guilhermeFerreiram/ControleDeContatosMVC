using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class AlterarSenha
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a nova senha atual")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha atual")]
        [Compare("NovaSenha", ErrorMessage = "Senha não confere com a nova senha")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
