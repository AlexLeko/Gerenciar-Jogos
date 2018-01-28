using GerenciarJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarJogos.Infra.Data.EntityConfig
{
    internal class TipoConsoleConfiguration : EntityTypeConfiguration<TipoConsole>
    {
        public TipoConsoleConfiguration()
        {
            HasKey(c => c.ConsoleId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

        }
    }
}
