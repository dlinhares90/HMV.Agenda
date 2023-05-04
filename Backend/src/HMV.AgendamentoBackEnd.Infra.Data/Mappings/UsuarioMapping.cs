using HMV.AgendamentoBackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMV.AgendamentoBackEnd.Infra.Data.Mappings
{
    class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO_NEUROCOR");
            builder.HasKey(e => e.Id).HasName("PK_IdUsuario_Neurocor");
            builder.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(e => e.PacienteId).HasColumnName("cd_paciente");
        }
    }
}
