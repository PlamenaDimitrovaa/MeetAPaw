using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetAPaw.Data.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Address", "Breed", "Color", "DateOfBirth", "Description", "Gender", "ImageUrl", "Name", "OwnerId", "PetTypeId" },
                values: new object[] { 4, "Pleven, Bulgaria", "Persian", "White", new DateTime(2021, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "The White Persian cat is an enchanting feline with a regal appearance and striking snowy fur. Its luxurious, long coat exudes elegance and grace, captivating admirers with its soft, fluffy texture. Known for their gentle and calm demeanor, these majestic cats make wonderful companions, offering affectionate companionship and a serene presence in any home. With their captivating blue or copper eyes and distinctive flat face, the White Persian cat is a true symbol of beauty and tranquility.", 1, "https://img.freepik.com/premium-photo/exotic-shorthair-kitten-4-months-old-exotic-shorthair-kitten_191971-4692.jpg?w=740", "Joy", new Guid("84520237-aa53-4477-a543-7b10c4fd91a1"), 2 });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Address", "Breed", "Color", "DateOfBirth", "Description", "Gender", "ImageUrl", "Name", "OwnerId", "PetTypeId" },
                values: new object[] { 5, "Plovdiv, Bulgaria", "Tame", "Blue", new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The tame bird: A delightful, sociable companion with vibrant plumage, friendly nature, and joyful melodies. Perfect for brightening your days with its charming presence.", 1, "https://img.freepik.com/premium-photo/budgie-blue-isolated-white-budgerigar-full-growth_157837-168.jpg?w=740", "Rebeka", new Guid("ed65de1e-17b1-434a-a3a9-6d8700564e23"), 3 });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Address", "Breed", "Color", "DateOfBirth", "Description", "Gender", "ImageUrl", "Name", "OwnerId", "PetTypeId" },
                values: new object[] { 6, "Varna, Bulgaria", "Dutch", "White", new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dutch Rabbit is a small, adorable breed known for its distinctive white blaze on the face and a colored band around the body. It's a friendly and charming companion, perfect for families and rabbit enthusiasts.", 0, "https://img.freepik.com/premium-photo/little-rabbit-white_21730-6890.jpg?w=740", "Yohan", new Guid("ed65de1e-17b1-434a-a3a9-6d8700564e23"), 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
