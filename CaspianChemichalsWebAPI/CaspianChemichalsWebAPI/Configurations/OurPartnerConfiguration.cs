using CaspianChemichalsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaspianChemichalsWebAPI.Configurations
{
    public class OurPartnerConfiguration : IEntityTypeConfiguration<OurPartner>
    {
        public void Configure(EntityTypeBuilder<OurPartner> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
