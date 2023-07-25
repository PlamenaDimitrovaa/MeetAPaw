using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetAPaw.Data.Migrations
{
    public partial class SeedingDataForSheltersAndPetTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PetsTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Bird" },
                    { 4, "Rabbit" }
                });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Blagoevgrad, Bulgaria", "MeetYourFriend" },
                    { 2, "Sofia, Bulgaria", "MakeTheAnimalsHappy" },
                    { 3, "Plovdiv, Bulgaria", "AnimalWorld" },
                    { 4, "Yambol, Bulgaria", "FindYourFluffyFriend" },
                    { 5, "Stara Zagora, Bulgaria", "EveryLifeMatters" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetsTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetsTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PetsTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PetsTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
