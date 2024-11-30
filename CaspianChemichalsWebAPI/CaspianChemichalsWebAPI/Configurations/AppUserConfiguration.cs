using CaspianChemichalsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaspianChemichalsWebAPI.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(30);
            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
