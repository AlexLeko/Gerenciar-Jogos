using GerenciarJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarJogos.Infra.Data.EntityConfig
{
    internal class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(u => u.UsuarioId);

            Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(8);

        }
    }
}
