
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
                OwnerId = Guid.Parse("84520237-AA53-4477-A543-7B10C4FD91A1")
            };

            pets.Add(pet);

            pet = new Pet()
            {
                Id = 4,
                Name = "Joy",
                PetTypeId = 2,
                Breed = "Persian",
                Color = "White",
                ImageUrl = "https://img.freepik.com/premium-photo/exotic-shorthair-kitten-4-months-old-exotic-shorthair-kitten_191971-4692.jpg?w=740",
                DateOfBirth = DateTime.Parse("11/06/2021"),
                Address = "Pleven, Bulgaria",
                Description = "The White Persian cat is an enchanting feline with a regal appearance and " +
                "striking snowy fur. Its luxurious, long coat exudes elegance and grace, captivating admirers" +
                " with its soft, fluffy texture. Known for their gentle and calm demeanor, these majestic" +
                " cats make wonderful companions, offering affectionate companionship and a serene presence " +
                "in any home. With their captivating blue or copper eyes and distinctive flat face, the White " +
                "Persian cat is a true symbol of beauty and tranquility.",
                Gender = Models.Enums.PetGender.Female,
                OwnerId = Guid.Parse("84520237-AA53-4477-A543-7B10C4FD91A1")
            };

            pets.Add(pet);

            pet = new Pet()
            {
                Id = 5,
                Name = "Rebeka",
                PetTypeId = 3,
                Breed = "Tame",
                Color = "Blue",
                ImageUrl = "https://img.freepik.com/premium-photo/budgie-blue-isolated-white-budgerigar-full-growth_157837-168.jpg?w=740",
                DateOfBirth = DateTime.Parse("02/02/2022"),
                Address = "Plovdiv, Bulgaria",
                Description = "The tame bird: A delightful, sociable companion with vibrant plumage, friendly nature, and joyful melodies. Perfect for brightening your days with its charming presence.",
                Gender = Models.Enums.PetGender.Female,
                OwnerId = Guid.Parse("ED65DE1E-17B1-434A-A3A9-6D8700564E23")
            };

            pets.Add(pet);

            pet = new Pet()
            {
                Id = 6,
                Name = "Yohan",
                PetTypeId = 4,
                Breed = "Dutch",
                Color = "White",
                ImageUrl = "https://img.freepik.com/premium-photo/little-rabbit-white_21730-6890.jpg?w=740",
                DateOfBirth = DateTime.Parse("07/07/2021"),
                Address = "Varna, Bulgaria",
                Description = "The Dutch Rabbit is a small, adorable breed known for its distinctive white blaze on the face and a colored band around the body. It's a friendly and charming companion, perfect for families and rabbit enthusiasts.",
                Gender = Models.Enums.PetGender.Male,
                OwnerId = Guid.Parse("ED65DE1E-17B1-434A-A3A9-6D8700564E23")
            };

            pets.Add(pet);

            return pets.ToArray();
        }
    }
}
