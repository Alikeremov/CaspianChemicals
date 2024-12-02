using CaspianChemichalsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaspianChemichalsWebAPI.Configurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.Tittle)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.Subtittle)
                .HasMaxLength(400)
                .IsRequired();
        }
    }
}
