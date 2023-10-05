using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using webapi.inlock_CodeFirst.Domains;

namespace webapi.inlock_CodeFirst.Contexts
{
    public class InLockContext : DbContext
    {
        // Mesmo nome da Entidade, mesmo nome da /*Tabela/Propriedade*/
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE14-S15; Database=inlock_games_codeFirst_tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}