
using MeetAPaw.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        public DbSet<Owner> Owners { get; set; } = null!;

        public DbSet<PetForAdoption> PetsForAdoption { get; set; } = null!;

        public DbSet<Shelter> Shelters { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(MeetAPawDbContext)) ??
                Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            builder.Entity<Adoption>()
                .HasOne(a => a.Adopter)
                .WithMany()
                .HasForeignKey(a => a.AdopterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Adoption>()
                .HasOne(a => a.PetForAdoption)
                .WithMany()
                .HasForeignKey(a => a.PetForAdoptionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Adoption>()
                .HasOne(a => a.Shelter)
                .WithMany()
                .HasForeignKey(a => a.ShelterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Pet>()
                .HasOne(p => p.PetType)
                .WithMany()
                .HasForeignKey(p => p.PetTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PetForAdoption>()
                .HasOne(p => p.PetType)
                .WithMany()
                .HasForeignKey(p => p.PetTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PetForAdoption>()
                .HasOne(p => p.Shelter)
                .WithMany(s => s.PetsForAdoption)
                .HasForeignKey(p => p.ShelterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Owner>()
               .HasMany(o => o.Pets)
               .WithOne(p => p.Owner)
               .HasForeignKey(p => p.OwnerId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }

}
