using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Freelando.Modelos;

namespace Freelando.Dados.Mapeamentos;

internal class EspecialidadeTypeConfiguration : IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> entity)
    {
        entity.ToTable("TB_Especialidades");
        entity.Property(e => e.Id).HasColumnName("ID_Especialidade");
        entity.Property(e => e.Descricao).HasColumnName("DS_Especialidade");
    }
}
