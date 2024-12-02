using CaspianChemichalsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaspianChemichalsWebAPI.Configurations
{
    public class OurPartnerTranslateConfiguration : IEntityTypeConfiguration<OurPartnerTranslate>
    {
        public void Configure(EntityTypeBuilder<OurPartnerTranslate> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
