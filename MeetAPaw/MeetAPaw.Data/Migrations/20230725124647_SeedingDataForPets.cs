using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetAPaw.Data.Migrations
{
    public partial class SeedingDataForPets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Address", "Breed", "Color", "DateOfBirth", "Description", "Gender", "ImageUrl", "Name", "OwnerId", "PetTypeId" },
                values: new object[] { 1, "Blagoevgrad, Bulgaria", "Chihuahua", "White", new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incredible dog with a lot of charm and cute vision.", 0, "https://img.freepik.com/free-photo/chihuahua-cute-pet-lovely-animal-cap-concept_53876-65101.jpg?w=996&t=st=1688976253~exp=1688976853~hmac=6cf748d837e8c94d718ff937d582bd777adf75521da98181da10ab93681d35d5", "Vais", new Guid("84520237-aa53-4477-a543-7b10c4fd91a1"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
