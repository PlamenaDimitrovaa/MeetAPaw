using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetAPaw.Data.Migrations
{
    public partial class ImageUrlAddedTOShelter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Shelters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MoreInformation",
                table: "Adoptions",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://img.freepik.com/free-icon/pet-hotel-sign-with-dog-cat-roof-line_318-51335.jpg?t=st=1692281759~exp=1692282359~hmac=304e10af9753d0851a5932db7643c5cd3669f222eef8af85c609233e298e2afc");

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://img.freepik.com/premium-photo/pet-doctor-vector-logo-ai-generated_879974-1190.jpg?w=996");

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://img.freepik.com/free-vector/hand-drawn-flat-dog-badge-logo_23-2149433387.jpg?w=826&t=st=1692281825~exp=1692282425~hmac=c693b37b236fc57e51c2c00466392f1e93be228cfd9fa9c899ec061841d87cf4");

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://img.freepik.com/premium-vector/cute-pet-shop-logo-vector-icon-illustration_441059-295.jpg?w=826");

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://img.freepik.com/free-vector/dog-abstract-outline-logo_530521-1355.jpg?w=826&t=st=1692281862~exp=1692282462~hmac=d06c06ead5b79fdc8e70080912952464c3bc675ea360389e0f0091fe14208264");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Shelters");

            migrationBuilder.AlterColumn<string>(
                name: "MoreInformation",
                table: "Adoptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);
        }
    }
}
