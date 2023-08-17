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
                Address = "Blagoevgrad, Bulgaria",
                ImageUrl = "https://img.freepik.com/free-icon/pet-hotel-sign-with-dog-cat-roof-line_318-51335.jpg?t=st=1692281759~exp=1692282359~hmac=304e10af9753d0851a5932db7643c5cd3669f222eef8af85c609233e298e2afc"
            };

            shelters.Add(shelter);

            shelter = new Shelter()
            {
                Id = 2,
                Name = "MakeTheAnimalsHappy",
                Address = "Sofia, Bulgaria",
                ImageUrl = "https://img.freepik.com/premium-photo/pet-doctor-vector-logo-ai-generated_879974-1190.jpg?w=996"
            };

            shelters.Add(shelter);

            shelter = new Shelter()
            {
                Id = 3,
                Name = "AnimalWorld",
                Address = "Plovdiv, Bulgaria",
                ImageUrl = "https://img.freepik.com/free-vector/hand-drawn-flat-dog-badge-logo_23-2149433387.jpg?w=826&t=st=1692281825~exp=1692282425~hmac=c693b37b236fc57e51c2c00466392f1e93be228cfd9fa9c899ec061841d87cf4"
            };

            shelters.Add(shelter);

            shelter = new Shelter()
            {
                Id = 4,
                Name = "FindYourFluffyFriend",
                Address = "Yambol, Bulgaria",
                ImageUrl = "https://img.freepik.com/premium-vector/cute-pet-shop-logo-vector-icon-illustration_441059-295.jpg?w=826"
            };

            shelters.Add(shelter);

            shelter = new Shelter()
            {
                Id = 5,
                Name = "EveryLifeMatters",
                Address = "Stara Zagora, Bulgaria",
                ImageUrl = "https://img.freepik.com/free-vector/dog-abstract-outline-logo_530521-1355.jpg?w=826&t=st=1692281862~exp=1692282462~hmac=d06c06ead5b79fdc8e70080912952464c3bc675ea360389e0f0091fe14208264"
            };

            shelters.Add(shelter);

            return shelters.ToArray();
        }
    }
}
