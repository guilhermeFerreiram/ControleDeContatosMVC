using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
