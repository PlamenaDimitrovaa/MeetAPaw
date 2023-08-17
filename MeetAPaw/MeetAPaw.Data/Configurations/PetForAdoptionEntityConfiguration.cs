using MeetAPaw.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetAPaw.Data.Configurations
{
    public class PetForAdoptionEntityConfiguration : IEntityTypeConfiguration<PetForAdoption>
    {
        public void Configure(EntityTypeBuilder<PetForAdoption> builder)
        {
            builder.HasData(this.GeneratePetsForAdoption());
        }
        private PetForAdoption[] GeneratePetsForAdoption()
        {
            ICollection<PetForAdoption> petsForAdoption = new HashSet<PetForAdoption>();

            PetForAdoption petForAdoption;

            petForAdoption = new PetForAdoption()
            {
                Id = 10,
                Name = "Murphy",
                PetTypeId = 1,
                Breed = "Husky",
                Color = "Black-White",
                ImageUrl = "https://img.freepik.com/premium-photo/siberian-husky-9-months-old-sitting-front-white-background_191971-25663.jpg?w=740",
                DateOfBirth = DateTime.Parse("02/01/2022"),
                Description = "The Husky is a majestic and energetic breed known for its striking " +
                "wolf-like appearance, thick double coat, and captivating icy blue eyes." +
                " With a friendly and adventurous personality, these intelligent dogs make loyal companions" +
                " and excel in activities like sledding and hiking.",
                Gender = Models.Enums.PetGender.Male,
                IsAdopted = false,
                ShelterId = 1,
                UserId = Guid.Parse("ED65DE1E-17B1-434A-A3A9-6D8700564E23")
            };

            petsForAdoption.Add(petForAdoption);

            petForAdoption = new PetForAdoption()
            {
                Id = 11,
                Name = "Fris",
                PetTypeId = 2,
                Color = "Gray",
                ImageUrl = "https://img.freepik.com/premium-photo/brazilian-shorthair-cat-1-year-old-cat-portrait-isolated_191971-1674.jpg?w=740",
                DateOfBirth = DateTime.Parse("03/11/2022"),
                Description = "The cat, a graceful and independent creature, exudes a sense of mystery and elegance. " +
                "With its soft fur, agile movements, and " +
                "keen senses, the cat embodies a perfect balance of playfulness and poise.",
                Gender = Models.Enums.PetGender.Male,
                IsAdopted = false,
                ShelterId = 2,
                UserId = Guid.Parse("84520237-AA53-4477-A543-7B10C4FD91A1")
            };

            petsForAdoption.Add(petForAdoption);

            petForAdoption = new PetForAdoption()
            {
                Id = 12,
                Name = "Grina",
                PetTypeId = 2,
                Breed = "Siamese",
                Color = "Black-Beige",
                ImageUrl = "https://img.freepik.com/free-psd/beautiful-cat-portrait-isolated_23-2150186058.jpg?w=740&t=st=1690920220~exp=1690920820~hmac=4690269afdee8f82a5dc9cabaf3651fae42c36e5868a72e450ac64333b26222e",
                DateOfBirth = DateTime.Parse("02/08/2021"),
                Description = "The Siamese cat is a beautiful and charismatic " +
                "breed that stands out with its striking blue " +
                "almond-shaped eyes and sleek, slender body. Their short, " +
                "fine coat displays color points, with darker" +
                " color on their ears, face, paws, and tail. ",
                Gender = Models.Enums.PetGender.Female,
                IsAdopted = false,
                ShelterId = 3,
                UserId = Guid.Parse("ED65DE1E-17B1-434A-A3A9-6D8700564E23")
            };

            petsForAdoption.Add(petForAdoption);

            petForAdoption = new PetForAdoption()
            {
                Id = 13,
                Name = "Mora",
                PetTypeId = 3,
                Breed = "Cockatiel",
                Color = "Multicolor",
                ImageUrl = "https://img.freepik.com/premium-photo/cockatiel-nymphicus-hollandicus-isolated_191971-11574.jpg?w=740",
                DateOfBirth = DateTime.Parse("02/01/2022"),
                Description = "The parrot, a vibrant and intelligent " +
                "avian species, boasts a kaleidoscope" +
                " of colorful feathers that capture attention. ",
                Gender = Models.Enums.PetGender.Female,
                IsAdopted = false,
                ShelterId = 4,
                UserId = Guid.Parse("84520237-AA53-4477-A543-7B10C4FD91A1")
            };

            petsForAdoption.Add(petForAdoption);

            petForAdoption = new PetForAdoption()
            {
                Id = 14,
                Name = "Smith",
                PetTypeId = 4,
                Color = "White",
                ImageUrl = "https://img.freepik.com/free-photo/easter-bunny-colored-eggs-preparation-holiday-easter_1321-4393.jpg?w=740&t=st=1690920568~exp=1690921168~hmac=45b4830f0ec6d66b80711dc4afd42710bd3fc6c0a12a811716a044c26bdfc993",
                DateOfBirth = DateTime.Parse("08/01/2023"),
                Description = "The rabbit, a delightful and gentle " +
                "creature, captivates with its cute, twitching nose" +
                " and long, soft ears. With a variety of breeds" +
                " showcasing different sizes and coat colors, " +
                "rabbits are known for their curious and playful " +
                "nature.",
                Gender = Models.Enums.PetGender.Male,
                IsAdopted = false,
                ShelterId = 5,
                UserId = Guid.Parse("ED65DE1E-17B1-434A-A3A9-6D8700564E23")
            };

            petsForAdoption.Add(petForAdoption);

            return petsForAdoption.ToArray();
        }
    }
}
