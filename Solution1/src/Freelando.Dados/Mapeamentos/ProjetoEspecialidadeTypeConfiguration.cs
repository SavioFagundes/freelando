using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Freelando.Modelos;

namespace Freelando.Dados.Mapeamentos;

public class ProjetoEspecialidadeTypeConfiguration : IEntityTypeConfiguration<ProjetoEspecialidade>
{
    public void Configure(EntityTypeBuilder<ProjetoEspecialidade> entity)
    {
        entity.ToTable("TB_Especialidade_Projeto");
        entity.Property(e => e.ProjetoId).HasColumnName("Id_Projeto");
        entity.Property(e => e.EspecialidadeId).HasColumnName("Id_Especialidade");
    }
}
