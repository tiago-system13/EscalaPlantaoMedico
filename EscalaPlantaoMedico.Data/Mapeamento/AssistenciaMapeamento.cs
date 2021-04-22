using EscalaPlantaoMedico.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscalaPlantaoMedico.Data.Mapeamento
{
    public class AssistenciaMapeamento : IEntityTypeConfiguration<Assistencia>
    {
        public void Configure(EntityTypeBuilder<Assistencia> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("assistencia_id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
               .HasColumnName("procedimento")
               .HasMaxLength(150)
               .IsRequired();

            builder.ToTable("tb_assistencia");
        }
    }
}
