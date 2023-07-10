
using MeetAPaw.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetAPaw.Data.Configurations
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasData(this.GeneratePets());
        }

        private Pet[] GeneratePets()
        {
            ICollection<Pet> pets = new HashSet<Pet>();

            Pet pet;

            pet = new Pet()
            {
                Id = 1,
                Name = "Vais",
                PetTypeId = 1,
                Breed = "Chihuahua",
                Color = "White",
                ImageUrl = "https://img.freepik.com/free-photo/chihuahua-cute-pet-lovely-animal-cap-concept_53876-65101.jpg?w=996&t=st=1688976253~exp=1688976853~hmac=6cf748d837e8c94d718ff937d582bd777adf75521da98181da10ab93681d35d5",
                DateOfBirth = DateTime.Parse("11/11/2021"),
                Address = "Blagoevgrad, Bulgaria",
                Description = "Incredible dog with a lot of charm and cute vision.",
                Gender = Models.Enums.PetGender.Male,
                OwnerId = Guid.Parse("1cfeec8d-70dc-4bc3-ba9d-5f125b3a0c1a")
            };

            pets.Add(pet);

            return pets.ToArray();
        }
    }
}
