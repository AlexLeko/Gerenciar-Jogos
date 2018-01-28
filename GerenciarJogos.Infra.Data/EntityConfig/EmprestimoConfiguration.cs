using GerenciarJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciarJogos.Infra.Data.EntityConfig
{
    internal class EmprestimoConfiguration : EntityTypeConfiguration<Emprestimo>
    {
        public EmprestimoConfiguration()
        {
            HasKey(j => j.EmprestimoId);

            Property(j => j.Observacao)
                .HasMaxLength(500);

            HasRequired(j => j.Jogo)
                .WithMany()
                .HasForeignKey(j => j.JogoId);

            HasRequired(j => j.Amigo)
                .WithMany()
                .HasForeignKey(j => j.AmigoId);

        }
    }
}
