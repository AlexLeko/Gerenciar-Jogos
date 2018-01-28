using GerenciarJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarJogos.Infra.Data.EntityConfig
{
    internal class AmigoConfiguration : EntityTypeConfiguration<Amigo>
    {
        public AmigoConfiguration()
        {
            HasKey(j => j.AmigoId);

            Property(j => j.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(j => j.Apelido)
                .HasMaxLength(50);

            Property(j => j.Telefone)
                .IsRequired()
                .HasMaxLength(14);

            Property(j => j.Email)
                .HasMaxLength(200);

        }
    }
}
