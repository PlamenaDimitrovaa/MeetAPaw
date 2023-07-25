using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetAPaw.Data.Migrations
{
    public partial class RemovedAdopterTableAndAddedInverseProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoptions_Adopters_AdopterId",
                table: "Adoptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PetsForAdoption_Adopters_AdopterId",
                table: "PetsForAdoption");

            migrationBuilder.DropTable(
                name: "Adopters");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_AspNetUsers_AdopterId",
                table: "Adoptions",
                column: "AdopterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetsForAdoption_AspNetUsers_AdopterId",
                table: "PetsForAdoption",
                column: "AdopterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoptions_AspNetUsers_AdopterId",
                table: "Adoptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PetsForAdoption_AspNetUsers_AdopterId",
                table: "PetsForAdoption");

            migrationBuilder.CreateTable(
                name: "Adopters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adopters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adopters_UserId",
                table: "Adopters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_Adopters_AdopterId",
                table: "Adoptions",
                column: "AdopterId",
                principalTable: "Adopters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetsForAdoption_Adopters_AdopterId",
                table: "PetsForAdoption",
                column: "AdopterId",
                principalTable: "Adopters",
                principalColumn: "Id");
        }
    }
}
