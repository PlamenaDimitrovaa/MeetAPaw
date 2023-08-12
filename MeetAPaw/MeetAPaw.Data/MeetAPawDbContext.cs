
using MeetAPaw.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace MeetAPaw.Data
{
    public class MeetAPawDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public MeetAPawDbContext(DbContextOptions<MeetAPawDbContext> options)
            :base(options)
        {
           
        }

        public DbSet<Pet> Pets { get; set; } = null!;

        public DbSet<PetType> PetsTypes { get; set; } = null!;

        public DbSet<Adoption> Adoptions { get; set; } = null!;

        public DbSet<PetForAdoption> PetsForAdoption { get; set; } = null!;

        public DbSet<Shelter> Shelters { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(MeetAPawDbContext)) ??
                Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);

            builder.Entity<Adoption>()
            .HasOne(a => a.PetForAdoption)
            .WithMany()
            .HasForeignKey(a => a.PetForAdoptionId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Adoption>()
                .HasOne(a => a.Adopter)
                .WithMany()
                .HasForeignKey(a => a.AdopterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
