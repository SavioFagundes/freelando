using Freelando.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelando.Dados.Mapeamentos;

internal class CandidaturaTypeConfiguration : IEntityTypeConfiguration<Candidatura>
{
    public void Configure(EntityTypeBuilder<Candidatura> entity)
    {
        entity.ToTable("TB_Candidaturas");
        entity.Property(e => e.Id).HasColumnName("Id_Candidatura");
        entity.Property(e => e.ServicoId).HasColumnName("Id_Servico");
        entity.Property(e => e.ValorProposto).HasColumnName("Valor_Proposto");
        entity.Property(e => e.DescricaoProposta).HasColumnName("DS_Proposta");
        entity
            .Property(e => e.DuracaoProposta)
            .HasColumnName("Duracao_Proposta")
            .HasConversion(
                fromObj => fromObj.ToString(),
                fromDb => (DuracaoEmDias)Enum.Parse(typeof(DuracaoEmDias), fromDb)
            );
        entity
            .Property(e => e.Status)
            .HasConversion(
                fromObj => fromObj.ToString(),
                fromDb => (StatusCandidatura)Enum.Parse(typeof(StatusCandidatura), fromDb)
            );
        entity.HasOne(e => e.Servico)
            .WithMany(e => e.Candidaturas)
            .HasForeignKey(e => e.ServicoId);
    }
}
