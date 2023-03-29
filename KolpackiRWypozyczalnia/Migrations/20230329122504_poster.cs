using Microsoft.EntityFrameworkCore.Migrations;

namespace KolpackiRWypozyczalnia.Migrations
{
    public partial class poster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "PosterName",
                value: "teksanska-masakra-pila-mechaniczna.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "PosterName",
                value: null);
        }
    }
}
