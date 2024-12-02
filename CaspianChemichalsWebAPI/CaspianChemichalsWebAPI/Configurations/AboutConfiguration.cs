using CaspianChemichalsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaspianChemichalsWebAPI.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(x => x.Tittle)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x=>x.Description)
                .HasMaxLength(2500)
                .IsRequired();
            
        }
    }
}
