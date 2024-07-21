using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        Contato Adicionar(Contato contato);
        List<Contato> BuscarTodos(int usuarioId);
        Contato ListarPorId(int id);
        Contato Atualizar(Contato contato);
        bool Apagar(int id);
    }
}
