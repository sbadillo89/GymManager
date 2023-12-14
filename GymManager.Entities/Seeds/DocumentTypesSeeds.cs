using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Entities.Seeds
{
    public class DocumentTypesSeeds : IEntityTypeConfiguration<DocumentTypes>
    {
        public void Configure(EntityTypeBuilder<DocumentTypes> builder)
        {
            builder.HasData(
                new DocumentTypes(Guid.NewGuid(), "CEDULA DE CIUDADANIA", true),
                new DocumentTypes(Guid.NewGuid(), "CEDULA DE EXTRANJERIA", true),
                new DocumentTypes(Guid.NewGuid(), "TARJETA DE IDENTIDAD", true),
                new DocumentTypes(Guid.NewGuid(), "PASAPORTE", true),
                new DocumentTypes(Guid.NewGuid(), "NIP", true),
                new DocumentTypes(Guid.NewGuid(), "NIT", true)
            );
        }
    }
}