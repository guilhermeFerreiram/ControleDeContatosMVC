using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string login);
        Usuario BuscarPorEmailELogin(string email, string login);
        Usuario Adicionar(Usuario usuario);
        List<Usuario> BuscarTodos();
        Usuario ListarPorId(int id);
        Usuario Atualizar(Usuario usuario);
        bool Apagar(int id);
        Usuario AlterarSenha(AlterarSenha alterar);
    }
}
