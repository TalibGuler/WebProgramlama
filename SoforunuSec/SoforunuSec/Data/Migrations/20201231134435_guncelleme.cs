using Microsoft.EntityFrameworkCore.Migrations;

namespace SoforunuSec.Data.Migrations
{
    public partial class guncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fotograf",
                table: "Araba",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fotograf",
                table: "Araba");
        }
    }
}
