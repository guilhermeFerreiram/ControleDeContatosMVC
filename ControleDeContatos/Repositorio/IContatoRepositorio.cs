using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        Contato Adicionar(Contato contato);
        List<Contato> BuscarTodos();
    }
}
