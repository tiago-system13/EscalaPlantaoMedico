using EscalaPlantaoMedico.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscalaPlantaoMedico.Data.Mapeamento
{
    public class AtendimentoAssistencialMapeamento : IEntityTypeConfiguration<AtendimentoAssistencial>
    {
        public void Configure(EntityTypeBuilder<AtendimentoAssistencial> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("procedimento_assistencial_id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.AssistenciaId)
                   .HasColumnName("assistencia_id")
                   .IsRequired();

            builder.Property(x => x.DataAtendimento)
                   .HasColumnName("data_assistencia")
                   .IsRequired();

            builder.Property(x => x.IdentificacaoLeito)
                   .HasColumnName("nr_leito")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(x => x.PesoAtendimento)
                   .HasColumnName("peso_atendimento")                  
                   .IsRequired();

            builder.HasOne(x => x.Assistencia)
                       .WithMany(x => x.AtendimentosAssistenciais)
                       .HasForeignKey(x => x.AssistenciaId);

            builder.ToTable("tb_procedimento_assistencial");
        }
    }
}
