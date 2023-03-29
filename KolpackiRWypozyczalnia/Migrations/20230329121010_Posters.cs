using Microsoft.EntityFrameworkCore.Migrations;

namespace KolpackiRWypozyczalnia.Migrations
{
    public partial class Posters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterName",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "PosterName",
                value: "numer-23.jpg");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3,
                column: "PosterName",
                value: "sekretne-okno.jpg");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4,
                column: "PosterName",
                value: "wladca-pierscieni-druzyna-pierscienia.jpg");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5,
                column: "PosterName",
                value: "red.jpg");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6,
                column: "PosterName",
                value: "tylko-nie-mow-nikomu.jpg");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7,
                column: "PosterName",
                value: "iluzjonista.jpg");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 8,
                column: "PosterName",
                value: "cube.jpg");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 9,
                column: "PosterName",
                value: "hellriser.jpg");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 10,
                column: "PosterName",
                value: "milczenie-owiec.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterName",
                table: "Films");
        }
    }
}
