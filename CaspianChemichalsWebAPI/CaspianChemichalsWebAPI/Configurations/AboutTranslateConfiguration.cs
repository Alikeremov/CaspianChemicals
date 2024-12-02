using CaspianChemichalsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaspianChemichalsWebAPI.Configurations
{
    public class AboutTranslateConfiguration : IEntityTypeConfiguration<AboutTranslate>
    {
        public void Configure(EntityTypeBuilder<AboutTranslate> builder)
        {
            builder.Property(x => x.Tittle)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(2500)
                .IsRequired();

        }
    }
}
