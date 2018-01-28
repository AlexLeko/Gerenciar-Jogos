using GerenciarJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarJogos.Infra.Data.EntityConfig
{
    internal class JogoConfiguration : EntityTypeConfiguration<Jogo>
    {
        public JogoConfiguration()
        {
            HasKey(j => j.JogoId);

            Property(j => j.Nome)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(j => j.Console)
                .WithMany()
                .HasForeignKey(j => j.ConsoleId);

        }
    }
}
