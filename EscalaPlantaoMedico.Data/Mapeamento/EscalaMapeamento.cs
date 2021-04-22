using EscalaPlantaoMedico.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscalaPlantaoMedico.Data.Mapeamento
{
    public class EscalaMapeamento : IEntityTypeConfiguration<Escala>
    {
        public void Configure(EntityTypeBuilder<Escala> builder)
        {
            builder.HasKey(x => x.Id);
         
            builder.Property(x => x.Id)
                .HasColumnName("escala_id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.AtendimentoAssistencialId)
               .HasColumnName("procedimento_assistencial_id")
               .IsRequired();

            builder.Property(x => x.DataEscala)
               .HasColumnName("data_escala")              
               .IsRequired();

            builder.Property(x => x.Profissional)
               .HasColumnName("profissional")
               .HasMaxLength(30)
               .IsRequired();

            builder.HasOne(x => x.AtendimentoAssistencial)
                   .WithMany(x => x.Escalas)
                   .HasForeignKey(x => x.AtendimentoAssistencialId);

            builder.ToTable("tb_escala");
        }
    }
}
