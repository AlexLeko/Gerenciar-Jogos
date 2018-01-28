using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace GerenciarJogos.Infra.Data.Contexto
{
    public class GerenciarJogosContext : DbContext
    {
        #region [Construtor]
        public GerenciarJogosContext() : base("GerenciadorJogos")
        {

        }
        #endregion

        #region [DBSet]
        public DbSet<TipoConsole> Consoles { get; set; }

        public DbSet<Jogo> Jogos { get; set; }

        public DbSet<Amigo> Amigos { get; set; }

        public DbSet<Emprestimo> Emprestimos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        #endregion

        #region [Auxiliares]

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new TipoConsoleConfiguration());
            modelBuilder.Configurations.Add(new JogoConfiguration());
            modelBuilder.Configurations.Add(new AmigoConfiguration());
            modelBuilder.Configurations.Add(new EmprestimoConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = System.DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }



        #endregion

    }
}
