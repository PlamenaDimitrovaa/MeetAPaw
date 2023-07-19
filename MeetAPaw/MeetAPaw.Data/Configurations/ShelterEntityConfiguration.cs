
using MeetAPaw.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetAPaw.Data.Configurations
{
    public class ShelterEntityConfiguration : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder.HasData(GenerateShelters());
        }

        private Shelter[] GenerateShelters()
        {
            ICollection<Shelter> shelters = new HashSet<Shelter>();
            Shelter shelter;

            shelter = new Shelter()
            {
                Id = 1,
                Name = "MeetYourFriend",
                Address = "Blagoevgrad, Bulgaria"
            };

            shelters.Add(shelter);

            shelter = new Shelter()
            {
                Id = 2,
                Name = "MakeTheAnimalsHappy",
                Address = "Sofia, Bulgaria"
            };

            shelters.Add(shelter);

            shelter = new Shelter()
            {
                Id = 3,
                Name = "AnimalWorld",
                Address = "Plovdiv, Bulgaria"
            };

            shelters.Add(shelter);

            shelter = new Shelter()
            {
                Id = 4,
                Name = "FindYourFluffyFriend",
                Address = "Yambol, Bulgaria"
            };

            shelters.Add(shelter);

            shelter = new Shelter()
            {
                Id = 5,
                Name = "EveryLifeMatters",
                Address = "Stara Zagora, Bulgaria"
            };

            shelters.Add(shelter);

            return shelters.ToArray();
        }
    }
}
