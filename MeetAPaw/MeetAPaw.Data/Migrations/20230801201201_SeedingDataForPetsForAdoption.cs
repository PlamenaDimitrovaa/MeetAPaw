using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetAPaw.Data.Migrations
{
    public partial class SeedingDataForPetsForAdoption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PetsForAdoption",
                columns: new[] { "Id", "Address", "AdopterId", "Breed", "Color", "DateOfBirth", "Description", "Gender", "ImageUrl", "IsAdopted", "Name", "PetTypeId", "ShelterId", "UserId" },
                values: new object[,]
                {
                    { 10, null, null, "Husky", "Black-White", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Husky is a majestic and energetic breed known for its striking wolf-like appearance, thick double coat, and captivating icy blue eyes. With a friendly and adventurous personality, these intelligent dogs make loyal companions and excel in activities like sledding and hiking.", 0, "https://img.freepik.com/premium-photo/siberian-husky-9-months-old-sitting-front-white-background_191971-25663.jpg?w=740", false, "Murphy", 1, 1, new Guid("ed65de1e-17b1-434a-a3a9-6d8700564e23") },
                    { 11, null, null, null, "Gray", new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The cat, a graceful and independent creature, exudes a sense of mystery and elegance. With its soft fur, agile movements, and keen senses, the cat embodies a perfect balance of playfulness and poise.", 0, "https://img.freepik.com/premium-photo/brazilian-shorthair-cat-1-year-old-cat-portrait-isolated_191971-1674.jpg?w=740", false, "Fris", 2, 2, new Guid("84520237-aa53-4477-a543-7b10c4fd91a1") },
                    { 12, null, null, "Siamese", "Black-Beige", new DateTime(2021, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Siamese cat is a beautiful and charismatic breed that stands out with its striking blue almond-shaped eyes and sleek, slender body. Their short, fine coat displays color points, with darker color on their ears, face, paws, and tail. ", 1, "https://img.freepik.com/free-psd/beautiful-cat-portrait-isolated_23-2150186058.jpg?w=740&t=st=1690920220~exp=1690920820~hmac=4690269afdee8f82a5dc9cabaf3651fae42c36e5868a72e450ac64333b26222e", false, "Grina", 2, 3, new Guid("ed65de1e-17b1-434a-a3a9-6d8700564e23") },
                    { 13, null, null, "Cockatiel", "Multicolor", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The parrot, a vibrant and intelligent avian species, boasts a kaleidoscope of colorful feathers that capture attention. ", 1, "https://img.freepik.com/premium-photo/cockatiel-nymphicus-hollandicus-isolated_191971-11574.jpg?w=740", false, "Mora", 3, 4, new Guid("84520237-aa53-4477-a543-7b10c4fd91a1") },
                    { 14, null, null, null, "White", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The rabbit, a delightful and gentle creature, captivates with its cute, twitching nose and long, soft ears. With a variety of breeds showcasing different sizes and coat colors, rabbits are known for their curious and playful nature.", 0, "https://img.freepik.com/free-photo/easter-bunny-colored-eggs-preparation-holiday-easter_1321-4393.jpg?w=740&t=st=1690920568~exp=1690921168~hmac=45b4830f0ec6d66b80711dc4afd42710bd3fc6c0a12a811716a044c26bdfc993", false, "Smith", 4, 5, new Guid("ed65de1e-17b1-434a-a3a9-6d8700564e23") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetsForAdoption",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PetsForAdoption",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PetsForAdoption",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PetsForAdoption",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PetsForAdoption",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
