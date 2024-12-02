using CaspianChemichalsWebAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CaspianChemichalsWebAPI.Contexts
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutTranslate> AboutTranslates { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderTranslate> SliderTranslates { get; set; }
        public DbSet<OurPartner> OurPartners { get; set; }
        public DbSet<OurPartnerTranslate> OurPartnerTranslates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
