
using MeetAPaw.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetAPaw.Data.Configurations
{
    public class PetTypeEntityConfiguration : IEntityTypeConfiguration<PetType>
    {
        public void Configure(EntityTypeBuilder<PetType> builder)
        {
            builder.HasData(this.GeneratePetTypes());
        }

        private PetType[] GeneratePetTypes()
        {
            ICollection<PetType> types = new HashSet<PetType>();

            PetType petType;

            petType = new PetType()
            {
                Id = 1,
                Name = "Dog"
            };

            types.Add(petType);

            petType = new PetType()
            {
                Id = 2,
                Name = "Cat"
            };

            types.Add(petType);

            petType = new PetType()
            {
                Id = 3,
                Name = "Bird"
            };

            types.Add(petType);

            petType = new PetType()
            {
                Id = 4,
                Name = "Rabbit"
            };

            types.Add(petType);

            return types.ToArray();
        }
    }
}
